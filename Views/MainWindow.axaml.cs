using Avalonia.Controls;
using Avalonia.Interactivity;
using System;
namespace PasswordGenerator.Views;

public partial class MainWindow : Window
{
    private string _chars = "abcdefghijklmnopqrstuvwxyz";
    private Random _random = new();
    private int _size = 12;
    private string _generatedPassword = "";
    
    public MainWindow()
    {
        InitializeComponent();
    }
    
    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        _generatedPassword = "";

        _size = Convert.ToInt32(NumericUpDown.Text);
        
        if (Numbers.IsChecked == true)
            _chars += "0123456789";

        if (Letters.IsChecked == true)
            _chars += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        
        if (Signs.IsChecked == true)
            _chars += "!@#$%^&*(){}|_+?/*-+";
            
        for ( var i = 0; i < _size; i++ )
            _generatedPassword += _chars[_random.Next(_chars.Length)];

        Output.Text = _generatedPassword;
        _chars = "abcdefghijklmnopqrstuvwxyz";
    }

    private void Copy_OnClick(object? sender, RoutedEventArgs e)
    {
        if (Output.Text != null)
           Clipboard?.SetTextAsync(Output.Text);
    }
}