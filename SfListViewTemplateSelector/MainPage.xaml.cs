namespace SfListViewTemplateSelector
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

			BindingContext = new ViewModel();
		}
		
	}

	public class ViewModel
	{

		public ViewModel()
		{
			for (int i = 0; i < 100; i++)
			{
				Items.Add(100.ToString());
			}
		}

		public List<string> Items { get; } = new();
	}

	public class Selector : DataTemplateSelector
	{
		protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
		{
			return new DataTemplate(() => new Label() { Text = "Hi"});
		}
	}
}
