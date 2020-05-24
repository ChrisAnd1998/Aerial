Option Strict On

Imports System.ComponentModel
Imports System.Runtime.InteropServices

Public Class Form1

    Private Declare Function SHAppBarMessage Lib "shell32.dll" Alias "SHAppBarMessage" _
    (ByVal dwMessage As Integer, <MarshalAs(UnmanagedType.Struct)> ByRef pData As _
    APPBARDATA) As Integer



    Private Structure APPBARDATA
        Public cbSize As Integer
        Public hWnd As IntPtr
        Public uCallbackMessage As Integer
        Public uEdge As Integer
        Public rc As RECT
        Public lParam As IntPtr
    End Structure
    Private Structure RECT
        Public left As Integer
        Public top As Integer
        Public right As Integer
        Public bottom As Integer
    End Structure

    Private Enum ABMsg As Integer
        ABM_NEW = 0
        ABM_REMOVE = 1
        ABM_QUERYPOS = 2
        ABM_SETPOS = 3
        ABM_GETSTATE = 4
        ABM_GETTASKBARPOS = 5
        ABM_ACTIVATE = 6
        ABM_GETAUTOHIDEBAR = 7
        ABM_SETAUTOHIDEBAR = 8
        ABM_WINDOWPOSCHANGED = 9
        ABM_SETSTATE = 10
    End Enum

    Private Enum ABEdge As Integer
        ABE_LEFT = 0
        ABE_TOP = 1
        ABE_RIGHT = 2
        ABE_BOTTOM = 3
    End Enum
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load



    End Sub

    Sub reset()
        For Each ff As Form In Application.OpenForms
            Dim abd As New APPBARDATA
            abd.cbSize = Marshal.SizeOf(abd)
            abd.hWnd = ff.Handle

            SHAppBarMessage(CType(ABMsg.ABM_REMOVE, Integer), abd)

        Next

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        reset()


        Dim allScreens = Screen.AllScreens



        'Primary
        If CheckBox1.Checked = True Then
            For Each screen In allScreens
                If screen.Primary = True Then
                    Dim abd As New APPBARDATA
                    abd.cbSize = Marshal.SizeOf(abd)



                    Dim ff As New Form
                    ff.AutoScaleBaseSize = New System.Drawing.Size(1, 1)
                    ff.ClientSize = New System.Drawing.Size(100, 100)
                    ff.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
                    ff.Opacity = 0
                    ff.Name = "AerialSpacer"
                    ff.ShowInTaskbar = False
                    ff.Show()

                    abd.hWnd = ff.Handle

                    abd.uEdge = CInt(ABEdge.ABE_TOP)
                    abd.rc.left = screen.WorkingArea.Left
                    abd.rc.right = screen.WorkingArea.Right
                    abd.rc.top = screen.WorkingArea.Top
                    abd.rc.bottom = screen.WorkingArea.Bottom

                    SHAppBarMessage(CType(ABMsg.ABM_NEW, Integer), abd)
                    SHAppBarMessage(CInt(ABMsg.ABM_QUERYPOS), abd)


                    abd.rc.bottom = abd.rc.top + CInt(TextBox1.Text)

                    SHAppBarMessage(CInt(ABMsg.ABM_SETPOS), abd)

                End If
            Next
        End If

        If CheckBox2.Checked = True Then
            For Each screen In allScreens
                If screen.Primary = True Then
                    Dim abd As New APPBARDATA
                    abd.cbSize = Marshal.SizeOf(abd)



                    Dim ff As New Form
                    ff.AutoScaleBaseSize = New System.Drawing.Size(1, 1)
                    ff.ClientSize = New System.Drawing.Size(100, 100)
                    ff.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
                    ff.Opacity = 0
                    ff.Name = "AerialSpacer"
                    ff.ShowInTaskbar = False
                    ff.Show()

                    abd.hWnd = ff.Handle

                    abd.uEdge = CInt(ABEdge.ABE_BOTTOM)
                    abd.rc.left = screen.WorkingArea.Left
                    abd.rc.right = screen.WorkingArea.Right
                    abd.rc.top = screen.WorkingArea.Top
                    abd.rc.bottom = screen.WorkingArea.Bottom

                    SHAppBarMessage(CType(ABMsg.ABM_NEW, Integer), abd)
                    SHAppBarMessage(CInt(ABMsg.ABM_QUERYPOS), abd)


                    abd.rc.top = abd.rc.bottom - CInt(TextBox3.Text)


                    SHAppBarMessage(CInt(ABMsg.ABM_SETPOS), abd)

                End If
            Next
        End If

        If CheckBox3.Checked = True Then
            For Each screen In allScreens
                If screen.Primary = True Then
                    Dim abd As New APPBARDATA
                    abd.cbSize = Marshal.SizeOf(abd)



                    Dim ff As New Form
                    ff.AutoScaleBaseSize = New System.Drawing.Size(1, 1)
                    ff.ClientSize = New System.Drawing.Size(100, 100)
                    ff.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
                    ff.Opacity = 0
                    ff.Name = "AerialSpacer"
                    ff.ShowInTaskbar = False
                    ff.Show()

                    abd.hWnd = ff.Handle

                    abd.uEdge = CInt(ABEdge.ABE_LEFT)
                    abd.rc.left = screen.WorkingArea.Left
                    abd.rc.right = screen.WorkingArea.Right
                    abd.rc.top = screen.WorkingArea.Top
                    abd.rc.bottom = screen.WorkingArea.Bottom

                    SHAppBarMessage(CType(ABMsg.ABM_NEW, Integer), abd)
                    SHAppBarMessage(CInt(ABMsg.ABM_QUERYPOS), abd)


                    abd.rc.right = abd.rc.left + CInt(TextBox4.Text)


                    SHAppBarMessage(CInt(ABMsg.ABM_SETPOS), abd)

                End If
            Next
        End If


        If CheckBox4.Checked = True Then
            For Each screen In allScreens
                If screen.Primary = True Then
                    Dim abd As New APPBARDATA
                    abd.cbSize = Marshal.SizeOf(abd)



                    Dim ff As New Form
                    ff.AutoScaleBaseSize = New System.Drawing.Size(1, 1)
                    ff.ClientSize = New System.Drawing.Size(100, 100)
                    ff.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
                    ff.Opacity = 0
                    ff.Name = "AerialSpacer"
                    ff.ShowInTaskbar = False
                    ff.Show()

                    abd.hWnd = ff.Handle

                    abd.uEdge = CInt(ABEdge.ABE_RIGHT)
                    abd.rc.left = screen.WorkingArea.Left
                    abd.rc.right = screen.WorkingArea.Right
                    abd.rc.top = screen.WorkingArea.Top
                    abd.rc.bottom = screen.WorkingArea.Bottom

                    SHAppBarMessage(CType(ABMsg.ABM_NEW, Integer), abd)
                    SHAppBarMessage(CInt(ABMsg.ABM_QUERYPOS), abd)


                    abd.rc.left = abd.rc.right - CInt(TextBox5.Text)


                    SHAppBarMessage(CInt(ABMsg.ABM_SETPOS), abd)

                End If
            Next
        End If


        'Secondary
        If CheckBox8.Checked = True Then
            For Each screen In allScreens
                If screen.Primary = False Then
                    Dim abd As New APPBARDATA
                    abd.cbSize = Marshal.SizeOf(abd)



                    Dim ff As New Form
                    ff.AutoScaleBaseSize = New System.Drawing.Size(1, 1)
                    ff.ClientSize = New System.Drawing.Size(100, 100)
                    ff.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
                    ff.Opacity = 0
                    ff.Name = "AerialSpacer"
                    ff.ShowInTaskbar = False
                    ff.Show()

                    abd.hWnd = ff.Handle

                    abd.uEdge = CInt(ABEdge.ABE_TOP)
                    abd.rc.left = screen.WorkingArea.Left
                    abd.rc.right = screen.WorkingArea.Right
                    abd.rc.top = screen.WorkingArea.Top
                    abd.rc.bottom = screen.WorkingArea.Bottom

                    SHAppBarMessage(CType(ABMsg.ABM_NEW, Integer), abd)
                    SHAppBarMessage(CInt(ABMsg.ABM_QUERYPOS), abd)

                    abd.rc.bottom = abd.rc.top + CInt(TextBox8.Text)

                    SHAppBarMessage(CInt(ABMsg.ABM_SETPOS), abd)

                End If
            Next
        End If

        If CheckBox7.Checked = True Then
            For Each screen In allScreens
                If screen.Primary = False Then
                    Dim abd As New APPBARDATA
                    abd.cbSize = Marshal.SizeOf(abd)



                    Dim ff As New Form
                    ff.AutoScaleBaseSize = New System.Drawing.Size(1, 1)
                    ff.ClientSize = New System.Drawing.Size(100, 100)
                    ff.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
                    ff.Opacity = 0
                    ff.Name = "AerialSpacer"
                    ff.ShowInTaskbar = False
                    ff.Show()

                    abd.hWnd = ff.Handle

                    abd.uEdge = CInt(ABEdge.ABE_BOTTOM)
                    abd.rc.left = screen.WorkingArea.Left
                    abd.rc.right = screen.WorkingArea.Right
                    abd.rc.top = screen.WorkingArea.Top
                    abd.rc.bottom = screen.WorkingArea.Bottom

                    SHAppBarMessage(CType(ABMsg.ABM_NEW, Integer), abd)
                    SHAppBarMessage(CInt(ABMsg.ABM_QUERYPOS), abd)


                    abd.rc.top = abd.rc.bottom - CInt(TextBox7.Text)


                    SHAppBarMessage(CInt(ABMsg.ABM_SETPOS), abd)

                End If
            Next
        End If


        If CheckBox6.Checked = True Then
            For Each screen In allScreens
                If screen.Primary = False Then
                    Dim abd As New APPBARDATA
                    abd.cbSize = Marshal.SizeOf(abd)



                    Dim ff As New Form
                    ff.AutoScaleBaseSize = New System.Drawing.Size(1, 1)
                    ff.ClientSize = New System.Drawing.Size(100, 100)
                    ff.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
                    ff.Opacity = 0
                    ff.Name = "AerialSpacer"
                    ff.ShowInTaskbar = False
                    ff.Show()

                    abd.hWnd = ff.Handle

                    abd.uEdge = CInt(ABEdge.ABE_LEFT)
                    abd.rc.left = screen.WorkingArea.Left
                    abd.rc.right = screen.WorkingArea.Right
                    abd.rc.top = screen.WorkingArea.Top
                    abd.rc.bottom = screen.WorkingArea.Bottom

                    SHAppBarMessage(CType(ABMsg.ABM_NEW, Integer), abd)
                    SHAppBarMessage(CInt(ABMsg.ABM_QUERYPOS), abd)


                    abd.rc.right = abd.rc.left + CInt(TextBox6.Text)


                    SHAppBarMessage(CInt(ABMsg.ABM_SETPOS), abd)

                End If
            Next
        End If

        If CheckBox5.Checked = True Then
            For Each screen In allScreens
                If screen.Primary = False Then
                    Dim abd As New APPBARDATA
                    abd.cbSize = Marshal.SizeOf(abd)



                    Dim ff As New Form
                    ff.AutoScaleBaseSize = New System.Drawing.Size(1, 1)
                    ff.ClientSize = New System.Drawing.Size(100, 100)
                    ff.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
                    ff.Opacity = 0
                    ff.Name = "AerialSpacer"
                    ff.ShowInTaskbar = False
                    ff.Show()

                    abd.hWnd = ff.Handle

                    abd.uEdge = CInt(ABEdge.ABE_RIGHT)
                    abd.rc.left = screen.WorkingArea.Left
                    abd.rc.right = screen.WorkingArea.Right
                    abd.rc.top = screen.WorkingArea.Top
                    abd.rc.bottom = screen.WorkingArea.Bottom

                    SHAppBarMessage(CType(ABMsg.ABM_NEW, Integer), abd)
                    SHAppBarMessage(CInt(ABMsg.ABM_QUERYPOS), abd)


                    abd.rc.left = abd.rc.right - CInt(TextBox5.Text)


                    SHAppBarMessage(CInt(ABMsg.ABM_SETPOS), abd)

                End If
            Next
        End If


    End Sub

    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        reset()
    End Sub
End Class
