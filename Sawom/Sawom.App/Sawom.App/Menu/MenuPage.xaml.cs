using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sawom.App.Menu
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MenuPage : MasterDetailPage
    {
		public MenuPage ()
		{
			InitializeComponent ();
            this.init();
        }

        void init()
        {
            List<Menu> menu = new List<Menu>
            {
                new Menu{ PageSelected = new View.HomePage(), MenuTitle = "Inicio", MenuDetail = "Página principal" },
                new Menu{ PageSelected = new View.PanelPage(), MenuTitle = "Panel", MenuDetail = "Visualizar mapa de alertas" },
                new Menu{ PageSelected = new View.AlertPage(), MenuTitle = "Alertas", MenuDetail = "Generar alerta" },
                new Menu{ PageSelected = new View.SettingsPage(), MenuTitle = "Configuración", MenuDetail = "Configurar Sawom" },
            };

            ListMenu.ItemsSource = menu;
            ListMenu.Margin = new Thickness(0, 21, 0, 0);
            Detail = new NavigationPage(new View.HomePage());


        }

        private void ListMenu_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var menu = e.SelectedItem as Menu;
            if (menu != null)
            {
                IsPresented = false;
                Detail = new NavigationPage(menu.PageSelected);
            }
        }

        #region Clase Menú
        class Menu
        {
            public String MenuTitle { get; set; }

            public String MenuDetail { get; set; }

            public Page PageSelected { get; set; }
        }
        #endregion
    }
}