using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DBManager
{


    public static string nom;
    public static string email;
    public static string prenom;
    public static string ville;
    public static string psw;
    public static string numero;


    public static bool loggedIn { get { return nom != null; } }


    public static void LogOut()
    {
        nom = null;
    }

}