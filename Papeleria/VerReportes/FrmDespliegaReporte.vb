Imports Microsoft.Reporting.WinForms
Imports LogicaNegocio

Public Class FrmDespliegaReporte
    Private miReporte As ReportViewer
    Private dataSource As ReportDataSource
    Private listaVentas As List(Of ResumenVentas)

    Public Sub New(ByVal listaVentas As List(Of ResumenVentas))
        InitializeComponent()
        miReporte = New ReportViewer
        Me.listaVentas = listaVentas
        MostrarReporteVentas()
    End Sub

    Private Sub MostrarReporteVentas()
        Me.Text = "Reporte de Ventas"
        miReporte.Dock = DockStyle.Fill
        miReporte.ProcessingMode = ProcessingMode.Local
        dataSource = New ReportDataSource("Datos", Me.listaVentas)
        miReporte.LocalReport.DataSources.Clear()
        miReporte.LocalReport.DataSources.Add(dataSource)
        miReporte.LocalReport.ReportPath = "Reportes\Ventas.rdlc"
        Dim parametros As New List(Of ReportParameter)
        parametros.Add(New ReportParameter("Total", String.Format("{0:C}", Me.listaVentas.Sum(Function(i) i.Total))))
        miReporte.LocalReport.SetParameters(parametros)
        Me.Controls.Add(miReporte)
        miReporte.RefreshReport()
    End Sub

End Class

