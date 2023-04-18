using Microsoft.Win32;
using pz_010.Backroll;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace pz_010;
public partial class MainWindow : Window
{
    List<ComboBoxItem> fontSizes;
    Album photoAlbum;

    public MainWindow()
    {
        InitializeComponent();

        photoAlbum = new(new Stack<Photo>());

        fontSizes = new List<ComboBoxItem>();
        makeFontSizes();
        
    }

    #region TextEditorModel
    void makeFontSizes()
    {
        for (int i = 0; i < 10; i++)
        {
            fontSizes.Add(new ComboBoxItem { Content = $"{14 + i*2}" });
            newFontSize.Items.Add(fontSizes[i]);
        }
    }

    //  exit
    private void MenuItem_Click(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }

    private void MenuItem_Click_Bold(object sender, RoutedEventArgs e)
    {
        //textBox.Selection.ApplyPropertyValue(FontSizeProperty, FontSize-FontSize+18);
        textBox.Selection.ApplyPropertyValue(FontWeightProperty, FontWeights.Bold);
    }
    private void MenuItem_Click_Italic(object sender, RoutedEventArgs e)
    {
        textBox.Selection.ApplyPropertyValue(FontStyleProperty, FontStyles.Italic);
    }

    private async void newFontSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        await Task.Delay(250);
        //MessageBox.Show(((ComboBox)sender).SelectionBoxItem.ToString());
        textBox.Selection.ApplyPropertyValue(FontSizeProperty, ((ComboBox)sender).SelectionBoxItem);
    }

    private void MenuItem_Click_Save(object sender, RoutedEventArgs e)
    {
        SaveFileDialog dialog = new();
        dialog.FileName = "index";
        dialog.DefaultExt = ".html";
        dialog.Filter = "Rich Text Files(*.rtf)|*.rtf|html Files(*.html)|*.html|All(*.*)|*";
        dialog.ShowDialog();

        var writeHere = dialog.OpenFile();

        //  особенности ричтекстбокса
        TextRange text = new(textBox.Document.ContentStart, textBox.Document.ContentEnd);
        text.Save(writeHere, DataFormats.Rtf);

        writeHere.Close();
        //using (StreamWriter sw = new(dialog.OpenFile()))
        //{
        //    text.Save(sw, "");
        //}
    }

        #endregion

    async Task TimerStart()
    {
        //System.InvalidOperationException:
        //"Вызывающий поток не может получить доступ к
        //данному объекту, так как владельцем этого объекта
        //является другой поток."

        TimerCallback tc = new TimerCallback(makeOnePhoto);
        Timer timer = new(tc, null, 0, 5000);
    }

    private void Button_Click_in(object sender, RoutedEventArgs e)
    {
        makeOnePhoto();

        //switch (MessageBox.Show("save too?", "?", MessageBoxButton.YesNo))
        //{
        //    case MessageBoxResult.Yes:
        //        MenuItem_Click_Save(new object(), new RoutedEventArgs());
        //        break;
        //    case MessageBoxResult.No:
        //        break;
        //    default:
        //        break;
        //}
    }

    //  альбом - массив сномкав - состояний(документ) ричтекстбокса
    void makeOnePhoto(object? a = null)
    {
        photoAlbum.photos.Push(new Photo(textBox.Document));
        MessageBox.Show("take photo");
    }

    private void Button_Click_out(object sender, RoutedEventArgs e)
    {
        //textBox.Document.UpdateDefaultStyle();

        try
        {
            textBox.Document = photoAlbum.photos.Pop().text;
        }
        catch (Exception ex) 
        { 
            MessageBox.Show(ex.Message); 
        }
    }

    private async void Window_Loaded(object sender, RoutedEventArgs e)
    {
        //Dispatcher.InvokeAsync(()=> Task.Run(() => TimerStart()));
        //Dispatcher.Invoke(()=>TimerStart());
        //await TimerStart();
    }
}