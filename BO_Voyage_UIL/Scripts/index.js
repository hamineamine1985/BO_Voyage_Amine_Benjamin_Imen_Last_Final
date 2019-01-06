



//Fonction JQUERY pour que l'image au fond soit toujours fixe et adaptée à la taille du navigateur
function redimensionnement() {

    var $image = $('img.imgfondfixe');
    var image_width = $image.width();
    var image_height = $image.height();

    var over = image_width / image_height;
    var under = image_height / image_width;

    var body_width = $(window).width();
    var body_height = $(window).height();

    if (body_width / body_height >= over) {
        $image.css({
            'width': body_width + 'px',
            'height': Math.ceil(under * body_width) + 'px',
            'left': '0px',
            'top': Math.abs((under * body_width) - body_height) / -2 + 'px'
        });
    }

    else {
        $image.css({
            'width': Math.ceil(over * body_height) + 'px',
            'height': body_height + 'px',
            'top': '0px',
            'left': Math.abs((over * body_height) - body_width) / -2 + 'px'
        });
    }
}

$(document).ready(function () {

    // Au chargement initial
    redimensionnement();

    // En cas de redimensionnement de la fenêtre
    $(window).resize(function () {
        redimensionnement();
    });

});

  //Fonction JQUERY pour éviter de déformer la liste déroulante avec un nom trop long, et qui prend en compte tous les évènements liés à la liste
if (!$.support.leadingWhitespace) { // if IE6/7/8
    $('select.wide')
        .bind('focus mouseover', function () { $(this).addClass('expand').removeClass('clicked'); })
        .bind('click', function () { $(this).toggleClass('clicked'); })
        .bind('mouseout', function () { if (!$(this).hasClass('clicked')) { $(this).removeClass('expand'); } })
        .bind('blur', function () { $(this).removeClass('expand clicked'); });
}

//Filtre des clients par type de Voyage.
$('#typevoy').change(function () {
    var idVoy = $("#typevoy option:selected")[0].text;
    $.ajax({
        type: 'GET',
        url: 'http://localhost:64402/api/Voyage/' + idVoy,
        contentType: 'application/json',
        success: function (data) {
            $("#liste").empty();
            $(data).each(function () {
                var ligne = $("<tr></tr>");
                ligne.append($("<input type='checkbox' >"));
                ligne.append($("<td>" + this.Nom + "</td>"));
                ligne.append($("<td>" + this.Prenom + "</td>"));
                ligne.append($("<td>" + this.Mail + "</td>"));
                $("#liste").append(ligne);
            });
        },
        error: function (xhr, status, error) {
            $("#message").html("Erreur de communication");
        }
    });
});
//Filtre des clients par région.
$('#reg').change(function () {
    var idReg = $("#reg option:selected")[0].text;
    $.ajax({
        type: 'GET',
        url: 'http://localhost:64402/api/Region/' + idReg,
        contentType: 'application/json',
        success: function (data) {
            $("#liste").empty();
            $(data).each(function () {
                var ligne = $("<tr id='id'></tr>");
                ligne.append($("<input type='checkbox' >"));
                ligne.append($("<td>" + this.Nom + "</td>"));
                ligne.append($("<td>" + this.Prenom + "</td>"));
                ligne.append($("<td>" + this.Mail + "</td>"));
                $("#liste").append(ligne);
            });
        },
        error: function (xhr, status, error) {
            $("#message").html("Erreur de communication");
        }
    });
});
//Filtre des clients qui ont plus de 18 ans. 
$('#agecli').change(function () {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:64402/api/TriAge/',
        contentType: 'application/json',
        success: function (data) {
            $("#liste").empty();
            $(data).each(function () {
                var ligne = $("<tr></tr>");
                ligne.append($("<input type='checkbox' >"));
                ligne.append($("<td>" + this.Nom + "</td>"));
                ligne.append($("<td>" + this.Prenom + "</td>"));
                ligne.append($("<td>" + this.Mail + "</td>"));
                $("#liste").append(ligne);
            });
        },
        error: function (xhr, status, error) {
            $("#message").html("Erreur de communication");
        }
    });
});
//Permet d'enregistrer une liste des clients dans la base de données (pas fonctionnel à 100%)
$('#btn3').click(function () {
    var Id = $("#id").attr('IdClient')
    $.ajax({
        type: 'GET',
        url: 'http://localhost:64402/api/Enreg/' + Id,
        //                contentType: 'application/json'
        success: function () {
            alert('La liste est bien sauvegardée')
        },
        error: function (xhr, status, error) {
            $("#message").html("Erreur de communication");
        }
    });
});
//Permet de sélectionner une ou plusieurs ligne de clients pour les supprimer de la liste.
$('#btn1').click(function deleteRow() {
    $("tr:has(input:checked)").remove();
}
);
//Permet de vider la liste obtenue pour recommencer. 
$('#btn2').click(function VideListe() {
    $("#liste").empty();
});

