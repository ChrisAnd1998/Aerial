Option Strict On

Imports System.ComponentModel
Imports System.Runtime.InteropServices
Imports Microsoft.Win32.TaskScheduler

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

        Try
            For Each prog As Process In Process.GetProcesses
                If prog.ProcessName = "Aerial" Then
                    If Not prog.Id = Process.GetCurrentProcess.Id Then
                        prog.Kill()
                    End If
                End If
            Next
        Catch
        End Try


        Try

            Using ts As TaskService = New TaskService()

                Dim td = ts.GetTask("Aerial")

                Dim cfg As String = Nothing

                cfg = td.Definition.Actions.ToString.Replace(System.AppDomain.CurrentDomain.BaseDirectory & "Aerial.exe", "")


                Dim arguments() As String = cfg.Split(CType(" ", Char()))

                For Each argument In arguments
                    Dim val() As String = Split(argument, "=")
                    '  Console.WriteLine(val(0))

                    If argument.Contains("-pa") Then
                        CheckBox1.Checked = True
                        NumericUpDown1.Value = CDec(val(1))
                    End If

                    If argument.Contains("-pb") Then
                        CheckBox2.Checked = True
                        NumericUpDown2.Value = CDec(val(1))
                    End If

                    If argument.Contains("-pc") Then
                        CheckBox3.Checked = True
                        NumericUpDown3.Value = CDec(val(1))
                    End If

                    If argument.Contains("-pd") Then
                        CheckBox4.Checked = True
                        NumericUpDown4.Value = CDec(val(1))
                    End If


                    If argument.Contains("-sa") Then
                        CheckBox5.Checked = True
                        NumericUpDown8.Value = CDec(val(1))
                    End If

                    If argument.Contains("-sb") Then
                        CheckBox6.Checked = True
                        NumericUpDown7.Value = CDec(val(1))
                    End If

                    If argument.Contains("-sc") Then
                        CheckBox7.Checked = True
                        NumericUpDown6.Value = CDec(val(1))
                    End If

                    If argument.Contains("-sd") Then
                        CheckBox8.Checked = True
                        NumericUpDown5.Value = CDec(val(1))
                    End If

                Next

                ' Console.WriteLine(td.Definition.Actions.ToString)

                Dim lg As LogonTrigger = CType(td.Definition.Triggers.Item(0), LogonTrigger)
                Dim times As TimeSpan = lg.Delay

                NumericUpDown9.Value = times.Seconds
            End Using
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try


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


        go()



    End Sub

    Sub go()
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


                    abd.rc.bottom = abd.rc.top + CInt(NumericUpDown1.Value)

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


                    abd.rc.top = abd.rc.bottom - CInt(NumericUpDown2.Value)


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


                    abd.rc.right = abd.rc.left + CInt(NumericUpDown3.Value)


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


                    abd.rc.left = abd.rc.right - CInt(NumericUpDown4.Value)


                    SHAppBarMessage(CInt(ABMsg.ABM_SETPOS), abd)

                End If
            Next
        End If


        'Secondary
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

                    abd.uEdge = CInt(ABEdge.ABE_TOP)
                    abd.rc.left = screen.WorkingArea.Left
                    abd.rc.right = screen.WorkingArea.Right
                    abd.rc.top = screen.WorkingArea.Top
                    abd.rc.bottom = screen.WorkingArea.Bottom

                    SHAppBarMessage(CType(ABMsg.ABM_NEW, Integer), abd)
                    SHAppBarMessage(CInt(ABMsg.ABM_QUERYPOS), abd)

                    abd.rc.bottom = abd.rc.top + CInt(NumericUpDown8.Value)

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


                    abd.rc.top = abd.rc.bottom - CInt(NumericUpDown6.Value)


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


                    abd.rc.right = abd.rc.left + CInt(NumericUpDown7.Value)


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


                    abd.rc.left = abd.rc.right - CInt(NumericUpDown8.Value)


                    SHAppBarMessage(CInt(ABMsg.ABM_SETPOS), abd)

                End If
            Next
        End If




        Dim parameters As String

        If CheckBox1.Checked = True Then
            parameters = parameters & " -pa=" & NumericUpDown1.Value
        End If
        If CheckBox2.Checked = True Then
            parameters = parameters & " -pb=" & NumericUpDown2.Value
        End If
        If CheckBox3.Checked = True Then
            parameters = parameters & " -pc=" & NumericUpDown3.Value
        End If
        If CheckBox4.Checked = True Then
            parameters = parameters & " -pd=" & NumericUpDown4.Value
        End If

        If CheckBox8.Checked = True Then
            parameters = parameters & " -sa=" & NumericUpDown5.Value
        End If
        If CheckBox7.Checked = True Then
            parameters = parameters & " -sb=" & NumericUpDown6.Value
        End If
        If CheckBox6.Checked = True Then
            parameters = parameters & " -sc=" & NumericUpDown7.Value
        End If
        If CheckBox5.Checked = True Then
            parameters = parameters & " -sd=" & NumericUpDown8.Value
        End If

        Try
            Using ts As TaskService = New TaskService()
                ts.RootFolder.DeleteTask("Aerial")
            End Using
        Catch ex As Exception
        End Try

        Try
            Using ts As TaskService = New TaskService()

                Dim td As TaskDefinition = ts.NewTask()
                Dim delay As Integer = CInt(NumericUpDown9.Value)

                td.RegistrationInfo.Description = "Claim desktop spaces"

                td.Triggers.Add(New LogonTrigger With {
                    .UserId = System.Security.Principal.WindowsIdentity.GetCurrent().Name,
                    .Delay = TimeSpan.FromSeconds(delay)})

                td.Settings.DisallowStartIfOnBatteries = False
                td.Settings.StopIfGoingOnBatteries = False
                td.Settings.RunOnlyIfIdle = False
                td.Settings.IdleSettings.RestartOnIdle = False
                td.Settings.IdleSettings.StopOnIdleEnd = False
                td.Settings.Hidden = True
                td.Settings.ExecutionTimeLimit = TimeSpan.Zero
                td.RegistrationInfo.Author = "Chris Andriessen"

                td.Actions.Add(New ExecAction(System.AppDomain.CurrentDomain.BaseDirectory & "Aerial.exe", parameters, Nothing))


                ts.RootFolder.RegisterTaskDefinition("Aerial", td)

            End Using
        Catch ex As Exception
            ' MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        reset()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        Dim arguments() As String = Environment.GetCommandLineArgs
        Dim tt As String

        Try
            tt = arguments(1).ToString
        Catch ex As Exception
            tt = ""
        End Try


        If tt.ToString.Contains("=") Then
            For Each argument In arguments
                Dim val() As String = Split(argument, "=")
                If argument.Contains("-pa") Then
                    CheckBox1.Checked = True
                    NumericUpDown1.Value = CDec(val(1))
                End If

                If argument.Contains("-pb") Then
                    CheckBox2.Checked = True
                    NumericUpDown2.Value = CDec(val(1))
                End If

                If argument.Contains("-pc") Then
                    CheckBox3.Checked = True
                    NumericUpDown3.Value = CDec(val(1))
                End If

                If argument.Contains("-pd") Then
                    CheckBox4.Checked = True
                    NumericUpDown4.Value = CDec(val(1))
                End If


                If argument.Contains("-sa") Then
                    CheckBox5.Checked = True
                    NumericUpDown8.Value = CDec(val(1))
                End If

                If argument.Contains("-sb") Then
                    CheckBox6.Checked = True
                    NumericUpDown7.Value = CDec(val(1))
                End If

                If argument.Contains("-sc") Then
                    CheckBox7.Checked = True
                    NumericUpDown6.Value = CDec(val(1))
                End If

                If argument.Contains("-sd") Then
                    CheckBox8.Checked = True
                    NumericUpDown5.Value = CDec(val(1))
                End If
            Next

            go()

            Me.Visible = False
            Me.Hide()
            Me.ShowInTaskbar = False
        End If


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            Using ts As TaskService = New TaskService()
                ts.RootFolder.DeleteTask("Aerial")
            End Using
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        End
    End Sub
End Class
