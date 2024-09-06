using Syncfusion.Maui.DataSource;

namespace SfListViewTemplateSelector
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

			BindingContext = new ViewModel();

			//ListView.DataSource.GroupDescriptors.Add(new GroupDescriptor()
			//{
			//	PropertyName = "Type",
			//	KeySelector = o =>
			//	{
			//		return "Group";
			//	}
			//});
		}

	}

	public class ViewModel
	{

		public ViewModel()
		{
			for (int i = 0; i < 100; i++)
			{
				Items.Add(i);
			}
		}

		public List<int> Items { get; } = new();
	}

	public class Selector : DataTemplateSelector
	{
		protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
		{
			var i = (int)item;
			
			if (i % 2 == 0)
			{
				return new DataTemplate(typeof(Template1));
			}
			else
			{
				return new DataTemplate(typeof(Template2));
			}
		}
	}
}
