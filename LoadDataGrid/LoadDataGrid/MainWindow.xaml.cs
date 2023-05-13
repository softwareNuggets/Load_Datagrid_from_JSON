using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.IO;


namespace LoadDataGrid
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}
		

		private void BtnLoad_Click(object sender, RoutedEventArgs e)
		{
			string fname = 
					@"C:\learn\c#\ObservablesExample\LoadDataGrid\LoadDataGrid\members.JSON";

			if (File.Exists(fname) == false)
			{
				Console.WriteLine(
					 $"{fname} is not available");
				return;
			}

			var json = 	File.ReadAllText(fname);
			List<People>? _people = JsonConvert.DeserializeObject<List<People>>(json);
			
			//clear out grid
			GridPeople.ItemsSource = null;

			if (_people != null)
			{
				GridPeople.ItemsSource = _people;
			}
		}

		private void BtnSave_Click(object sender, RoutedEventArgs e)
		{

			var data = (List<People>)this.GridPeople.ItemsSource;

			var json =
				 JsonConvert.SerializeObject(  data,   Formatting.Indented);


			string fname =
				@"C:\learn\c#\ObservablesExample\LoadDataGrid\LoadDataGrid\members.JSON";

			if (File.Exists(fname) == true)
			{
				File.Delete(fname);
			}

			File.WriteAllText(fname, json);

		}
	}
}
