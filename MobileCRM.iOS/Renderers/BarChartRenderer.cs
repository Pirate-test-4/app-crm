using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using MobileCRM.iOS.Renderers;
using System.ComponentModel;
[assembly: ExportRenderer(typeof(MobileCRM.CustomControls.BarChart), typeof(BarChartRenderer))]
namespace MobileCRM.iOS.Renderers
{

  public class BarChartRenderer : ViewRenderer<MobileCRM.CustomControls.BarChart, BarChart.BarChartView>
  {
    protected override void OnElementChanged(ElementChangedEventArgs<MobileCRM.CustomControls.BarChart> e)
    {
      base.OnElementChanged(e);
      if (e.OldElement != null || this.Element == null)
        return;
      var barChart = new BarChart.BarChartView()
      {
        ItemsSource = Element.Items.Select(item => new BarChart.BarModel
        {
          Value = item.Value,
          Legend = item.Name
        }).ToList()
      };
      SetNativeControl(barChart);
    }
    protected override void OnElementPropertyChanged (object sender, PropertyChangedEventArgs e) {
      base.OnElementPropertyChanged(sender, e);
      if (this.Element == null || this.Control == null)
        return;
      if (e.PropertyName == MobileCRM.CustomControls.BarChart.ItemsProperty.PropertyName)
      {
        Control.ItemsSource = Element.Items.Select(item => new BarChart.BarModel
        {
          Value = item.Value,
          Legend = item.Name
        }).ToList();
      } 
    }
  }
}