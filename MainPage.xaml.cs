using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Documents;
using CommunityToolkit.Maui.Views;
using Popup = CommunityToolkit.Maui.Views.Popup;

namespace MauApp;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
    }

    public Popup LockPopup { get; set; } = new Popup();

    private void LockApp(object sender, EventArgs e)
    {
        Label titleLabel = new Label { Text = " This is a lock popup, which SHOULD NOT be CLOSED by changing window size (Maximize or drag window border on Windows)", FontSize = 14, Margin = 20 };
        Entry entry = new Entry { Placeholder = "Enter password: 1", IsPassword = true, ReturnType = ReturnType.Go, WidthRequest = 240, Margin = 10 }; entry.Completed += Unlock; entry.Focus();
        Button unlockButton = new Button { Text = "Unlock", HeightRequest = 50, VerticalOptions = LayoutOptions.End, Margin = 10, BindingContext = entry }; unlockButton.Clicked += Unlock;
        StackLayout rootStack = new StackLayout { };
        rootStack.Children.Add(titleLabel); rootStack.Children.Add(entry); rootStack.Children.Add(unlockButton);

        LockPopup = new Popup() { Content = rootStack, CanBeDismissedByTappingOutsideOfPopup = false, Color = Color.FromRgba("#222222") };
        this.ShowPopup(LockPopup);
    }

    private void Unlock(object sender, EventArgs e)
    {
        Entry entry = sender.GetType() == typeof(Entry) ? sender as Entry : (sender as VisualElement).BindingContext as Entry;
        if (entry.Text == "1")
            LockPopup.Close();
    }

  
}

