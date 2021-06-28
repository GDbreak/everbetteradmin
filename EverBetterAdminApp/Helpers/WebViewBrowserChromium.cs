using IdentityModel.OidcClient.Browser;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Environment;

namespace EverBetterAdminApp.Helpers
{

    /// <summary>
    /// Implements the <see cref="IBrowser"/> interface using the <see cref="WebView2"/> control.
    /// </summary>
    public class WebViewBrowserChromium : IBrowser
    {
        private readonly Func<Form> _formFactory;

        /// <summary>
        /// Creates a new instance of <see cref="WebViewBrowserChromium"/> with a specified function to create the <see cref="Form"/>
        /// used to host the <see cref="WebView2"/> control.
        /// </summary>
        /// <param name="formFactory">The function used to create the <see cref="Form"/> that will host the <see cref="WebViewCompatible"/> control.</param>
        public WebViewBrowserChromium(Func<Form> formFactory)
        {
            _formFactory = formFactory;
        }

        /// <summary>
        /// Creates a new instance of <see cref="WebViewBrowserChromium"/> allowing parts of the <see cref="Form"/> container to be set.
        /// </summary>
        /// <param name="title">Optional title for the form - defaults to 'Authenticating...'.</param>
        /// <param name="width">Optional width for the form in pixels. Defaults to 1024.</param>
        /// <param name="height">Optional height for the form in pixels. Defaults to 768.</param>
        public WebViewBrowserChromium(string title = "Authenticating...", int width = 1024, int height = 768)
            : this(() => new Form
            {
                Name = "WebAuthentication",
                Text = title,
                Width = width,
                Height = height,
                
                
            })
        {
        }

        /// <inheritdoc />
        public async Task<BrowserResult> InvokeAsync(BrowserOptions options, CancellationToken cancellationToken = default)
        {
            var tcs = new TaskCompletionSource<BrowserResult>();

            var window = _formFactory();
            var webView = new WebView2 { Dock = DockStyle.Fill };
            var commonpath = GetFolderPath(SpecialFolder.CommonApplicationData);
            var path = Path.Combine(commonpath, "EverBetter Health LLC\\EverBetter Admin App");

            var env = await CoreWebView2Environment.CreateAsync(null, path, null);
            await webView.EnsureCoreWebView2Async(env);

            webView.NavigationStarting += (sender, e) =>
            {
                if (e.Uri.StartsWith(options.EndUrl))
                {

                    tcs.SetResult(new BrowserResult { ResultType = BrowserResultType.Success, Response = e.Uri.ToString() });
                    window.Close();

                }

            };

            window.Closing += (sender, e) =>
            {
                if (!tcs.Task.IsCompleted)
                    tcs.SetResult(new BrowserResult { ResultType = BrowserResultType.UserCancel });
            };


            window.Controls.Add(webView);
            window.Show();
            webView.CoreWebView2.Navigate(options.StartUrl);


            return await tcs.Task;
        }
    }
}