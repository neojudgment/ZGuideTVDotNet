Module Utilitaires
    Public Function EnlèveAccentEtAutres(ByVal Name As String) As String
        Dim NomCatMod As String = Name
        NomCatMod = NomCatMod.Replace("é", "e")
        NomCatMod = NomCatMod.Replace("è", "e")
        NomCatMod = NomCatMod.Replace("ë", "e")
        NomCatMod = NomCatMod.Replace("ê", "e")
        NomCatMod = NomCatMod.Replace("à", "a")
        NomCatMod = NomCatMod.Replace("@", "a")
        NomCatMod = NomCatMod.Replace("â", "a")
        NomCatMod = NomCatMod.Replace("ä", "a")
        NomCatMod = NomCatMod.Replace("î", "i")
        NomCatMod = NomCatMod.Replace("ï", "i")
        NomCatMod = NomCatMod.Replace("ù", "u")
        NomCatMod = NomCatMod.Replace("û", "u")
        NomCatMod = NomCatMod.Replace("ü", "u")
        NomCatMod = NomCatMod.Replace("&", "")
        NomCatMod = NomCatMod.Replace(" ", "")
        NomCatMod = NomCatMod.Replace("`", "")
        NomCatMod = NomCatMod.Replace("ñ", "n")
        Return NomCatMod
    End Function

End Module
