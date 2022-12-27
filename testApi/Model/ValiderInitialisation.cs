using Microsoft.AspNetCore.Hosting.Server;
using System.Data.SqlClient;
using Idylis_Framework.Idylis_DAL;
using static Idylis_Framework.Idylis_Application_FA.FA_Import;
using Idylis_Framework;
using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net;
namespace testApi.Model
{
    public static class ValiderInitialisation
    {
       public static string GetValiderInitialisation(string nRefUtilisateur,string cServeur,string cBase) {
            var cQuery = $"Select *, IsNull((Select top 1 1 From FA_GRILLEIMPORTMVTCAISSE where REFUTILISATEUR = " + nRefUtilisateur + "), 0) MVTCAISSE From FA_PARAMETRES_GENERAUX";           
            using (Idylis_DAO oDao = new Idylis_DAO(cServeur:cServeur, cBase: cBase))
            {
                SqlDataReader oDr = (SqlDataReader)oDao.ExecuterReader(cQuery);
                if (oDr.Read())
                {
                    Valeur lavaleur = new Valeur
                    {
                        Valeur1 = Idylis_Util.GetNum(oDr["TYPEPIECE_GRILLEIMPORT"]).ToString(),
                        Valeur2 = Idylis_Util.GetBoolean(oDr["NUMEROAUTOMATIQUE_GRILLEIMPORT"]).ToString(),
                        Valeur3 = Idylis_Util.GetNum(oDr["CREATIONAUTOCLIENT_GRILLEIMPORT"]).ToString(),
                        Valeur4 = Idylis_Util.GetNum(oDr["CREATIONAUTOCONTACTCLIENT_GRILLEIMPORT"]).ToString(),
                        Valeur5 = Idylis_Util.GetNum(oDr["CREATIONAUTOORIGINECLIENT_GRILLEIMPORT"]).ToString(),
                        Valeur6 = Idylis_Util.GetNum(oDr["CREATIONAUTODOSSIER_GRILLEIMPORT"]).ToString(),
                        Valeur7 = Idylis_Util.GetNum(oDr["CREATIONAUTOVENDEUR_GRILLEIMPORT"]).ToString(),
                        Valeur8 = Idylis_Util.GetNum(oDr["CREATIONAUTOARTICLE_GRILLEIMPORT"]).ToString(),
                        Valeur9 = Idylis_Util.GetNum(oDr["CREATIONAUTOCODEANALYTIQUE_GRILLEIMPORT"]).ToString(),
                        Valeur10 = Idylis_Util.GetZoneDecode(oDr["MODELEDOC_GRILLEIMPORT"]).ToString(),
                        Valeur11 = Idylis_Util.GetBoolean(oDr["MVTCAISSE"]).ToString(),
                        Valeur12 = Idylis_Util.GetBoolean(oDr["VALIDERPIECE_GRILLEIMPORT"]).ToString(),
                        Valeur13 = Idylis_Util.GetBoolean(oDr["REVALIDERPIECE_GRILLEIMPORT"]).ToString(),
                        Valeur14 = Idylis_Util.GetBoolean(oDr["FacturesNulles"]).ToString()
                    };
                    string json = JsonConvert.SerializeObject(lavaleur, Newtonsoft.Json.Formatting.Indented);
                    return json;
                }
                else
                    return "";
            }
        }
     
    }
}
