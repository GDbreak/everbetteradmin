using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace EverBetterAdminApp.Helpers
{
	public class BaseViewModel : INotifyPropertyChanged
	{
		#region INotifyPropertyChanged Data Members

		public event PropertyChangedEventHandler PropertyChanged;

		#endregion

		#region Constructors

		public BaseViewModel()
		{

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
