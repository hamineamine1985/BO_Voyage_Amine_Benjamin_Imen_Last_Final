using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
namespace BO_Voyage_UIL.Tools
{
    public class Dynamic_Properties
    {

 //Public shared_Attributes As New clsAttributesAutomation
 //Dim Dynamic_prop As New Dynamic_Properties
 // Dynamic_prop.CopyProprety_Form("clsGraphicsAutomation", Me.Name, Me, shared_Attributes)


        //public void CopyProprety_Form(String NameDst, String NameFrmSrc, Object objSrc, Object objDst)
        //{
        //    Object TmpObj;
        //    Type Typ;
        //    Type Typ2;
        //    int Err = 0;
        //    String strTmp = "";
        //    FieldInfo[] Fields; ;
        //    PropertyInfo[] Props;
        //    Object elSrc;
        //    Object CtrSrc;
        //    String NameSp = objDst.GetType().Namespace;
        //    Typ = Type.GetType(NameSp + "." + NameDst, false);
        //    Typ2 = Type.GetType(NameSp + "." + NameFrmSrc, false);
        //    if (Typ != null)
        //    {
        //        Fields = Typ.GetFields();         
        //        Props = Typ2.GetProperties();
        //        if (Fields != null)
        //        {
        //            foreach (var el in Fields)
        //            {
        //                strTmp = el.Name;
        //            foreach (elSrc in Props)
        //                {
        //                    if (elSrc.Name.CompareTo(el.Name) == 0)
        //                    {
        //                        TmpObj = elSrc.MetadataToken;                        
        //                        Object[] attrs = elSrc.GetCustomAttributes(false);   
        //                        try
        //                        {
        //                            CtrSrc = elSrc.GetValue(objSrc, null);
        //                            el.SetValue(objDst, CtrSrc);
        //                        }
        //                        catch (Exception ex)
        //                        {
        //                            Err = Err + 1;
        //                        }
        //                    }
                            
        //                }
        //            }
        //        }
        //    }
        //}
    }
}