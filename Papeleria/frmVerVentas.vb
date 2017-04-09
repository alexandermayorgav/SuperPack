Imports MonoReports.Model
Imports MonoReports.Model.Controls
Imports MonoReports.Model.Data
Imports MonoReports.Model.Color
Imports System.Collections.Generic
Imports System.Linq

Public Class frmVerVentas

    Private Sub frmVerVentas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub


    Private Sub process(ByVal rc As ReportContext, ByVal c As Control)
        If rc.RowIndex Mod 2 = 0 Then
            c.BackgroundColor = New Color(0.75, 0.75, 0.75, 1)
        Else
            DirectCast(TryCast(c, Section).Controls(1), TextBlock).FontColor = New Color(0.75, 0.75, 0.75, 1)
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Reporte()
    End Sub


    Public Sub Reporte()
        Dim r As New Report()
        '----------------------
        ' report header section
        '----------------------

        Dim invTextTb = New TextBlock() With { _
         .Text = "Invoice", _
         .Width = r.Width, _
         .FontWeight = FontWeight.Bold, _
         .FontSize = 14, _
         .HorizontalAlignment = HorizontalAlignment.Center _
        }
        r.ReportHeaderSection.Controls.Add(invTextTb)

        Dim invNumberTb = New TextBlock() With { _
         .FieldName = "invoice.Number", _
         .FieldKind = FieldKind.Parameter, _
         .Text = "Invoice", _
         .Width = r.Width, _
         .FontSize = 14, _
         .Top = 5.mm(), _
         .HorizontalAlignment = HorizontalAlignment.Center, _
         .FontColor = Color.White _
        }
        r.ReportHeaderSection.Height = 10.mm()
        r.ReportHeaderSection.Controls.Add(invNumberTb)
        r.ReportHeaderSection.BackgroundColor = Color.Silver


        '-------------------
        'page header section
        '-------------------

        Dim phLine = New Line() With { _
         .Location = New Point(0, 10.mm()), _
         .[End] = New Point(r.Width, 10.mm()), _
         .ExtendToBottom = True _
        }

        r.PageHeaderSection.Controls.Add(phLine)


        'index label
        Dim indhTb = New TextBlock() With { _
         .FontWeight = FontWeight.Bold, _
         .Text = "Ind", _
         .Width = 10.mm() _
        }
        r.PageHeaderSection.Controls.Add(indhTb)

        ' description label
        Dim deschTb = New TextBlock() With { _
         .FontWeight = FontWeight.Bold, _
         .Text = "Description", _
         .Left = 12.mm(), _
         .Width = 45.mm() _
        }
        r.PageHeaderSection.Controls.Add(deschTb)

        ' quantity label
        Dim qnthTb = New TextBlock() With { _
         .FontWeight = FontWeight.Bold, _
         .Text = "Quantity", _
         .Left = 50.mm() _
        }
        r.PageHeaderSection.Controls.Add(qnthTb)

        ' price field
        Dim prthTb = New TextBlock() With { _
         .FontWeight = FontWeight.Bold, _
         .Text = "Price", _
         .Left = 70.mm(), _
         .Width = 35.mm() _
        }
        r.PageHeaderSection.Controls.Add(prthTb)



        '---------------
        'details section
        '---------------

        'do not allow break detail section across page
        r.DetailSection.KeepTogether = True
        r.DetailSection.Height = 4.mm()

        'index field
        Dim indTb = New TextBlock() With { _
         .FieldName = "Index", _
         .FieldKind = FieldKind.Data, _
         .Text = "00", _
         .Left = 1.2.mm(), _
         .Width = 10.mm(), _
         .FontSize = 7 _
        }
        r.DetailSection.Controls.Add(indTb)

        ' description field
        Dim descTb = New TextBlock() With {.FieldName = "Description", .FieldKind = FieldKind.Data, .Text = "Desc", .Left = 12.mm(), .Width = 45.mm(), _
         .FontSize = 8}
        r.DetailSection.Controls.Add(descTb)

        ' quantity field
        Dim qntTb = New TextBlock() With { _
         .FieldName = "Quantity", _
         .FieldKind = FieldKind.Data, _
         .Text = "0", _
         .Left = 55.mm(), _
         .Width = 5.mm(), _
         .FontSize = 7 _
        }
        r.DetailSection.Controls.Add(qntTb)

        ' price field
        Dim prtTb = New TextBlock() With { _
         .FieldName = "PricePerUnitGross", _
         .FieldTextFormat = "{0:C}", _
         .FieldKind = FieldKind.Data, _
         .Text = "0", _
         .Left = 70.mm(), _
         .Width = 25.mm(), _
         .FontSize = 7 _
        }
        r.DetailSection.Controls.Add(prtTb)


        Dim line = New Line() With { _
         .Location = New Point(0, 2.mm()), _
         .[End] = New Point(r.Width, 2.mm()), _
         .ExtendToBottom = True _
        }
        r.DetailSection.Controls.Add(line)

        'just before processing we can change section properties
        AddHandler r.DetailSection.OnBeforeControlProcessing, AddressOf process ' Function(rc As ReportContext, c As Control) Do
        '     If rc.RowIndex Mod 2 = 0 Then
        '         c.BackgroundColor = Color.LightGray
        '     Else
        '         DirectCast(TryCast(c, Section).Controls(1), TextBlock).FontColor = Color.PaleVioletRed
        '     End If
        ' End Sub

        Dim lv0 = New Line() With { _
         .Location = New Point(70.mm(), 0), _
         .[End] = New Point(70.mm(), 2.mm()), _
         .ExtendToBottom = True _
        }
        r.DetailSection.Controls.Add(lv0)

        Dim lineV = New Line() With { _
         .Location = New Point(r.Width, 2.mm()), _
         .[End] = New Point(r.Width, 2.mm()), _
         .LineType = LineType.Dash, _
         .ExtendToBottom = True _
        }
        r.DetailSection.Controls.Add(lineV)


        '---------------
        'Report footer
        '---------------

        ' price field

        Dim prtTotalLabelTb = New TextBlock() With { _
         .FontWeight = FontWeight.Bold, _
         .HorizontalAlignment = HorizontalAlignment.Right, _
         .FontSize = 12, _
         .FieldKind = FieldKind.Parameter, _
         .Text = "Total: ", _
         .Left = 50.mm(), _
         .Width = 10.mm() _
        }

        r.ReportFooterSection.Controls.Add(prtTotalLabelTb)



        Dim prtTotalTb = New TextBlock() With { _
         .FontWeight = FontWeight.Bold, _
         .FieldName = "invoice.TotalGross", _
         .FieldTextFormat = "{0:C}", _
         .FontSize = 12, _
         .FieldKind = FieldKind.Parameter, _
         .Text = "0", _
         .Left = 62.mm(), _
         .Width = 40.mm() _
        }

        r.ReportFooterSection.Controls.Add(prtTotalTb)


        '---------------
        'Page footer
        '---------------
        Dim fl = New Line() With { _
         .Location = New Point(0, 1), _
         .[End] = New Point(r.Width, 1) _
        }
        r.PageFooterSection.Controls.Add(fl)

        Dim le = (r.Width - 15.mm())

        Dim pnTb = New TextBlock() With { _
         .FieldName = "#PageNumber", _
         .FieldTextFormat = "{0:d}", _
         .FieldKind = FieldKind.Expression, _
         .Text = "0", _
         .Left = le, _
         .Width = 10.mm(), _
         .HorizontalAlignment = HorizontalAlignment.Right, _
         .Top = 2.mm()}

        r.PageFooterSection.Controls.Add(pnTb)
        r.PageFooterSection.BackgroundColor = Color.Lavender

        '#Region "example invoice datasource"

        'example invoice class...
        Dim invoice As New Invoice() With { _
         .Number = "01/12/2010", _
         .CreationDate = DateTime.Now, _
         .Positions = New List(Of InvoicePosition)() _
        }

        For i As Integer = 0 To 81
            invoice.Positions.Add(New InvoicePosition() With { _
             .Index = i + 1, _
             .Quantity = 1, _
             .Description = "Reporting services " + (i + 1).ToString(), _
             .PricePerUnitGross = ((i * 50) / (i + 1)) + 1 _
            })
        Next


        invoice.Positions(4).Description = "here comes longer position text to see if position will extend section height"

        invoice.Positions(11).Description = "another longer position text to see if position will extend section height"


        'Total gross ...
        invoice.TotalGross = invoice.Positions.Sum(Function(p) p.PricePerUnitGross * p.Quantity)
        '#End Region

        r.DataSource = invoice.Positions
        Dim dic As New Dictionary(Of String, Object)

        dic.Add("invoice", invoice)

        r.ExportToPdf("invoice2.pdf", dic)
        r.Save("Reportes\report.mrp")

        'Dim pr As New Process
        'With pr
        '    .StartInfo.Verb = "print"
        '    .StartInfo.CreateNoWindow = False
        '    .StartInfo.FileName = "invoice2.pdf"
        '    .Start()
        '    .WaitForExit(10000)

        'End With

        'If Not pr.HasExited Then
        '    pr.CloseMainWindow()
        '    pr.Close()

        'End If



    End Sub

    Public Class Invoice

        Public Property Number() As String
            Get
                Return m_Number
            End Get
            Set(ByVal value As String)
                m_Number = value
            End Set
        End Property
        Private m_Number As String

        Public Property CreationDate() As DateTime
            Get
                Return m_CreationDate
            End Get
            Set(ByVal value As DateTime)
                m_CreationDate = value
            End Set
        End Property
        Private m_CreationDate As DateTime

        Public Property Positions() As List(Of InvoicePosition)
            Get
                Return m_Positions
            End Get
            Set(ByVal value As List(Of InvoicePosition))
                m_Positions = value
            End Set
        End Property
        Private m_Positions As List(Of InvoicePosition)

        Public Property TotalGross() As Double
            Get
                Return m_TotalGross
            End Get
            Set(ByVal value As Double)
                m_TotalGross = value
            End Set
        End Property
        Private m_TotalGross As Double
    End Class

    Public Class InvoicePosition

        Public Property Index() As Integer
            Get
                Return m_Index
            End Get
            Set(ByVal value As Integer)
                m_Index = value
            End Set
        End Property
        Private m_Index As Integer

        Public Property Description() As String
            Get
                Return m_Description
            End Get
            Set(ByVal value As String)
                m_Description = value
            End Set
        End Property
        Private m_Description As String

        Public Property Quantity() As Double
            Get
                Return m_Quantity
            End Get
            Set(ByVal value As Double)
                m_Quantity = value
            End Set
        End Property
        Private m_Quantity As Double

        Public Property PricePerUnitGross() As Double
            Get
                Return m_PricePerUnitGross
            End Get
            Set(ByVal value As Double)
                m_PricePerUnitGross = value
            End Set
        End Property
        Private m_PricePerUnitGross As Double

    End Class




    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim rep As New Report
        Dim invoice As New Invoice() With { _
 .Number = "01/12/2010", _
 .CreationDate = DateTime.Now, _
 .Positions = New List(Of InvoicePosition)() _
}

        For i As Integer = 0 To 81
            invoice.Positions.Add(New InvoicePosition() With { _
             .Index = i + 1, _
             .Quantity = 1, _
             .Description = "Reporting services " + (i + 1).ToString(), _
             .PricePerUnitGross = ((i * 50) / (i + 1)) + 1 _
            })
        Next
        invoice.TotalGross = invoice.Positions.Sum(Function(p) p.PricePerUnitGross * p.Quantity)

        rep.DataSource = invoice.Positions

        Dim dic As New Dictionary(Of String, Object)

        dic.Add("invoice", invoice)

        rep.Load("Reportes\orasifin.mrp")
        rep.ExportToPdf("new3.pdf", dic)
    End Sub
End Class