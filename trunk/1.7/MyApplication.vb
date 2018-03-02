Imports System.Threading
Imports Microsoft.VisualBasic.ApplicationServices

Namespace My

    ' Les événements suivants sont disponibles pour MyApplication :
    ' 
    ' Startup : déclenché au démarrage de l'application avant la création du formulaire de démarrage.
    ' Shutdown : déclenché après la fermeture de tous les formulaires de l'application. Cet événement n'est pas déclenché si l'application se termine de façon anormale.
    ' UnhandledException : déclenché si l'application rencontre une exception non gérée.
    ' StartupNextInstance : déclenché lors du lancement d'une application à instance unique et si cette application est déjà active. 
    ' NetworkAvailabilityChanged : déclenché lorsque la connexion réseau est connectée ou déconnectée.

    Partial Friend Class MyApplication

        Private Delegate Sub SafeApplicationThreadException(ByVal sender As Object,
                                                            ByVal e As ThreadExceptionEventArgs)

        Private Sub ShowDebugOutput(ByVal ex As Exception)

            ExceptError = vbLf + vbLf + ex.ToString()
            Feedback.ShowDialog()

            Environment.Exit(0)
        End Sub

        Private Sub MyApplicationStartup(ByVal sender As Object,
                                         ByVal e As StartupEventArgs) Handles Me.Startup

#If Not Debug Then
            ' On surveille les erreurs d'exception non gérées 
            AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf AppDomainUnhandledException
            ' AddHandler Application.ThreadException, AddressOf AppThreadException
#End If
        End Sub

        Private Sub AppThreadException(ByVal sender As Object,
                                       ByVal e As ThreadExceptionEventArgs)

            If MainForm.InvokeRequired Then
                MainForm.Invoke(New SafeApplicationThreadException(AddressOf AppThreadException),
                                New Object() {sender, e})
            Else
                ShowDebugOutput(e.Exception)
            End If
        End Sub

        Private Sub AppDomainUnhandledException(ByVal sender As Object,
                                                ByVal e As System.UnhandledExceptionEventArgs)

            ShowDebugOutput(DirectCast(e.ExceptionObject, Exception))
        End Sub
#If Not DEBUG Then
        Private Sub MyApplicationUnhandledException(sender As Object,
                                                    e As UnhandledExceptionEventArgs) _
            Handles Me.UnhandledException

            ShowDebugOutput(e.Exception)
        End Sub
        End Class
#End If
    End Class
End Namespace



