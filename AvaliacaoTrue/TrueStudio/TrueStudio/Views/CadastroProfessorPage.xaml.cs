﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TrueStudio.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CadastroProfessorPage
	{
		public CadastroProfessorPage ()
		{
			InitializeComponent ();
            BindingContext = new ViewModels.ProfessorViewModel();
        }
	}
}