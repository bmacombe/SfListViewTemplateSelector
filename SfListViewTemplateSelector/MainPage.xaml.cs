using Syncfusion.Maui.DataSource;
using Syncfusion.Maui.DataSource.Extensions;

namespace SfListViewTemplateSelector
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

			BindingContext = new ViewModel();

			ListView.DataSource.GroupDescriptors.Add(new GroupDescriptor()
			{
				PropertyName = "Group",
				KeySelector = o =>
				{
					if (o is DataItem item)
						return item.Group;
					return string.Empty;
				}
			});
		}

	}

	public class ViewModel
	{

		public ViewModel()
		{
			for (int i = 0; i < 100; i++)
			{
				Items.Add(new DataItem() { Count = i, Group = Math.Floor((double)(i/10)).ToString()});
			}
		}

		public List<DataItem> Items { get; } = new();
	}

	public class DataItem
	{
		public int Count { get; set; }
		public string Group { get; set; }

		public override string ToString()
		{
			return Count.ToString();
		}
	}

	public class Selector : DataTemplateSelector
	{
		protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
		{
			var i = (DataItem)item;

			if (i.Count % 2 == 0)
			{
				return new DataTemplate(typeof(Template1));
			}
			else
			{
				return new DataTemplate(typeof(Template2));
			}
		}
	}

	public class HeaderSelector : DataTemplateSelector
	{
		protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
		{
			var g = (GroupResult)item;
			return new DataTemplate(() => new Label() { Text = g.Key.ToString() });
		}
	}
}
