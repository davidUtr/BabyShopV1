using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyShoping.ViewModel
{
    class LoginViewModel : BaseViewModel
    {
        private string userName;
        public string UserName
        {
            get => userName;
            set => SetPropertyChanged(ref userName, value);
        }


    }
}
