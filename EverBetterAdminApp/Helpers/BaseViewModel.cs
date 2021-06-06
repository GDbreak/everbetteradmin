using EverBetterAdminApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;

namespace EverBetterAdminApp.Helpers
{
	public class BaseViewModel : INotifyPropertyChanged
	{
		#region INotifyPropertyChanged Data Members

		public event PropertyChangedEventHandler PropertyChanged;
		protected OAuthService _oAuthService;

		#endregion

		#region Constructors

		public BaseViewModel()
		{
			_oAuthService = ((App)Application.Current).oAuthService;
		}

		#endregion

		#region Members

		protected void raisePropertyChanged(String _propertyName)
		{
			PropertyChangedEventHandler handler = PropertyChanged;

			if (handler != null)
				handler(this, new PropertyChangedEventArgs(_propertyName));
		}


		#endregion
	}
}
