$(document).ready(function () {
$('#Continents').change(function (data) {
    RemoveAll();
    var pay = '#divPays';
    $(pay).empty();
    $("#message").empty();//    $(pay).append('<option>Choisir un Pay</option>');//value
    var idCont = $("#Continents option:selected").attr('value');// var idCont = $("#Continents option:selected").attr('id');
    $.ajax({
        type: 'GET',
        url: 'https://localhost:44382/' + Controleur+'/Pays/' + idCont,         //https://localhost:44382/Reserver/pays/?IdC=' + idCont,  //   http://localhost:56162/Reserver/Pays
        success: function (data) {
            $(pay).append(data);
            $('#Pays').append('<option value="0">Tous les pays</option>');
            PaysHandler();
        },
        error: function (xhr, status, error) {
            $("#message").empty();
            $("#message").append("Erreur de communication  =" + error);
        }
    })
})
function PaysHandler() {
    $('#Pays').change(function (data) {
        RemoveAll();
        var Reg = '#divRegs';
        $(Reg).empty();
        $("#message").empty();
        var idCont = $("#Continents option:selected").attr('value');
        var idPay = $("#Pays option:selected").attr('value');
        $.ajax({
            type: 'GET',
            url: 'https://localhost:44382/' + Controleur +'/Regions/' + idPay + '/' + idCont,
            success: function (data) {
                $(Reg).append(data);
                $("#Regions").append('<option value="0">Toutes les régions</option>');
                RegionssHandler();
            },
            error: function (xhr, status, error) {
                $("#message").empty();
                $("#message").append("Erreur de communication  =" + error);
            }
        })
    })
}

function RegionssHandler() {

    $('#Regions').change(function (data) {
        RemoveAll();
        var voy = '#divVoys';
        $(voy).empty();
        $("#message").empty();
        var idCont = $("#Continents option:selected").attr('value');
        var idPay = $("#Pays option:selected").attr('value');
        var idReg = $("#Regions option:selected").attr('value');
        $.ajax({
            type: 'GET',
            url: 'https://localhost:44382/' + Controleur +'/Voyages/' + idPay + '/' + idCont + '/' + idReg,
            success: function (data) {
                $(voy).append(data);               //$("#Voyages").append('<option value="0">Tous les voyages</option>');
                VoyagesHandler();
            },
            error: function (xhr, status, error) {
                $("#message").empty();
                $("#message").append("Erreur de communication  =" + error);
            }
        })
    })
}

function VoyagesHandler() {

    $('#Voyages').change(function (data) {
        RemoveAll();
        var div = '#detail';
        $("#message").empty();       
        var idVoy = $("#Voyages option:selected").attr('value');
        $.ajax({
            type: 'GET',
            url: 'https://localhost:44382/' + Controleur +'/Voyage/' + idVoy ,
            success: function (data) {    
                $(div).html(data);
                PayementHandler();
                SaveDossierHandler();
                setTimeout(function () { SaveDossierHandler();}, 2000); //alert("SaveDossierHandler"); 
            },
            error: function (xhr, status, error) {
                $("#message").empty();
                $("#message").append("Erreur de communication  =" + error);
            }
        })
    })

}
function RemoveAll() {

}

function PayementHandler() {
    var div = '#payement';
    $.ajax({
        type: 'GET',
        url: 'https://localhost:44382/' + Controleur +'/Payement/' ,
        success: function (data) {
            $(div).html(data);          
        },
        error: function (xhr, status, error) {
            $("#message").empty();
            $("#message").append("Erreur de communication  =" + error);
        }
    })
}

    function SaveDossierHandler() {
      //  alert('SaveDossierHandler   0');
    // $('#btnSubmit')    alert('SaveDossierHandler   0');
        $('#saveDossier').submit(function (event) {  //submit // $('#btnSubmit').click(function (data) {
    //    alert('SaveDossierHandler   2');
        //  data.preventDefault();
        $("#message").empty();
        var idVoy = $("#Voyages option:selected").attr('value');

        //   $("#email")        $("#cardNumber")        $("#expirationdate")        $("#NbreVoy")      
        var email = $("#email").val();
        var crypto = $("#cvv").val();
        var numCarte = $("#cardNumber").val();
        var NomCarte = $("#owner").val();
        var Expiration = "01/" + $("#expirationdate  option:selected").val() + "/" + $("#Annee option:selected").val();
        var NbVoyageur = parseInt($("#nbAdults").val());
        var AssuranceRpatri = false;//  $('#AssuranceRpatri:checked').val();
            $('#AssuranceRpatri[type=checkbox]:checked').each(function () { AssuranceRpatri = true; })
        var AssuranceAnnul =false;
        $('#AssuranceAnnul[type=checkbox]:checked').each(function () { AssuranceAnnul = true; })
        

        localStorage['email'] = email;
        localStorage['NomCarte'] = NomCarte;
        localStorage['NbVoyageur'] = $("#NbreVoy").val();
        //    var input = document.getElementById('saveServer').value;        localStorage.setItem('server', input);

        var Dossier = {
            Crypto :crypto,
            NomCarte: NomCarte,
            choixV: idVoy,
            emailAdress: email, //"toto@gmail.com",
            numCarte: numCarte, //"9996665557778882",
            Expiration: Expiration, //"Expiration210",
            NbVoyageur: NbVoyageur, //2
            AssuranceRpatri: AssuranceRpatri,
            AssuranceAnnul: AssuranceAnnul
        };
        Dossier = JSON.stringify(Dossier);
        $.ajax({
            type: 'POST',
            //Pay/Continent/reg
            data: Dossier,
            url: 'https://localhost:44382/' + Controleur +'/Save',                //contentType: 'application/json',
           //   dataType: "json",
            contentType: 'application/json',// "application/x-www-form-urlencoded; charset=UTF-8",
            success: function (data) {

         //   document.location.href = 'https://localhost:44382/' + Controleur +'/ConfirmationDossier';

                $("#Contenue").empty();
                $("#Contenue").append(data);
                //$(data).each(function () {
                //    // $(reg).append('<option id="' + this.IdV + '">' + this.NomV + '</option>');
                //    $("#message").append(data);
                //})
            },
            error: function (xhr, status, error) {
                //  $("#message").html("Erreur de communication");
                $("#message").empty();
                $("#message").append("Erreur de communication");
            }
        });
        //alert('Bravo vous etes con !');         document.location.href = "#popup1";
           
      return false;
    });
}
    //window.cookieconsent.initialise({
    //    "palette": {
    //        "popup": {
    //            "background": "#000"
    //        },
    //        "button": {
    //            "background": "#f1d600"
    //        }
    //    },
    //    "theme": "classic",
    //    "content": {
    //        "message": "En poursuivant votre navigation, vous acceptez l'utilisation de cookies ou technologies similaires, y compris de partenaires tiers pour la diffusion de publicité ciblée et de contenus pertinents au regard de vos centres d'intérêts.",
    //        "dismiss": "Ok",
    //        "link": "En savoir plus"
    //    }
    //});

$('#NbreVoy').on('keypress', function (evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;
    return true;
    });
});
