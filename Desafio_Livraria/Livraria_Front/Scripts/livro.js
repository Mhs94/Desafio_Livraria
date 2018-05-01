
$(document).ready(function () {
    var lar = window.screen.availHeight;
    var alt = window.screen.availWidth;
    window.resizeTo(alt, lar);
    loadData(1);
});



//Carregar tabela de livros; 1 se for carregar todos; outro numero para carregar um livro de determinado nome
function loadData(op) {

    URL = "";
    if (op == 1) { URL = "http://localhost:55972/api/Livro/Index"; }
    else {
        if ($('#BookName').val() == "") {
            URL = "http://localhost:55972/api/Livro/Index";
        }
        else {
            URL = "http://localhost:55972/api/Livro/SearchByName/" + $('#BookName').val();
        }
    }
    $.ajax({
        url: URL,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.livroId + '</td>';
                html += '<td>' + item.nome + '</td>';
                html += '<td>' + item.autor + '</td>';
                html += '<td>' + item.editora + '</td>';
                html += '<td>' + item.anoPublicacao + '</td>';

                html += '<td><a href="#" onclick="return getbyID(' + item.livroId + ')">Editar</a> | <a href="#" onclick="Delete(' + item.livroId + ')">Excluir</a></td>';
                html += '</tr>';
            });
            $('.tbody').html(html);
        },
        error: function (errormess) {
            alert(errormess.responseText);
        }
    });
}  
function SearchByName() {
    loadData(2);
}

//Adicionar um novo livro
function Add() {
    var res = validate();
    
    if (res == false) {
        return false;
    }
    var livroObj = {
        //LivroId: $('#LivroId').val(),
        Nome: $('#Name').val(),
        Autor: $('#Autor').val(),
        Editora: $('#Editora').val(),
        anoPublicacao: $('#anoPublicacao').val(),
        
    };
    $.ajax({
        url: "http://localhost:55972/api/Livro/Create",
        data: JSON.stringify(livroObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            $('#myModal').modal('hide');
            
            location.reload();  
            if (result == 0)
                alert("Não foi possível adicionar um novo livro. Tente novamente!")
            //loadData();
            
        },
        error: function (errormess) {
            alert(errormess.responseText);
        }
    });
}

//Function for getting the Data Based upon Employee ID  
function getbyID(LivroId) {
    $('#Name').css('border-color', 'lightgrey');
    $('#Autor').css('border-color', 'lightgrey');
    $('#Editora').css('border-color', 'lightgrey');
    $('#anoPublicacao').css('border-color', 'lightgrey');
    

    $.ajax({
        url: "http://localhost:55972/api/Livro/GetById/" + LivroId,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            if (result != 0) {
                $('#LivroId').attr("placeholder", result.livroId);
                $('#Autor').val(result.autor);
                $('#Name').val(result.nome);
                $('#Editora').val(result.editora);
                $('#anoPublicacao').val(result.anoPublicacao);


                $('#myModal').modal('show');
                $('#btnUpdate').show();
                $('#btnAdd').hide();
            }
            else {
                
                    alert("Não foi possível adicionar um novo livro. Tente novamente!")
            }
        },
        error: function (errormess) {
            alert(errormess.responseText);
        }
    });
    return false;
}

//metodo para atualizar um  livro
function Update() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var livroObj = {
        LivroId: $('#LivroId').attr("placeholder"),
        Nome: $('#Name').val(),
        Autor: $('#Autor').val(),
        Editora: $('#Editora').val(),
        anoPublicacao: $('#anoPublicacao').val(),
        
    };
    $.ajax({
        url: "http://localhost:55972/api/Livro/Update",
        data: JSON.stringify(livroObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData(1);
            $('#myModal').modal('hide');
            $('#LivroId').val("");
            $('#Autor').val("");
            $('#Name').val("");
            $('#Editora').val("");
            $('#anoPublicacao').val("");
            if (result == 0)
                alert("Não foi possível atualizar as informações do livro. Tente novamente!")
            
        },
        error: function (errormess) {
            alert(errormess.responseText);
        }
    });
}

//metodo para excluir um livro  
function Delete(ID) {
    var ans = confirm("Deseja excluir este livro?");
    if (ans) {
        $.ajax({
            url: "http://localhost:55972/api/Livro/Delete",
            data: JSON.stringify(ID),
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                if (result == 0)
                    alert("Não foi possível excluir o livro. Tente novamente!")
                location.reload();
            },
            error: function (errormess) {
                alert(errormess.responseText);
            }
        });
    }
}

//metodo para zerar as caixas de texto
function clearTextBox() {
    $('#LivroId').val("");
    $('#LivroId').attr("placeholder", "ID");
    $('#Name').val("");
    $('#Autor').val("");
    $('#Editora').val("");
    $('#anoPublicacao').val("");
    
    $('#btnUpdate').hide();
    $('#btnAdd').show();
    $('#Name').css('border-color', 'lightgrey');
    $('#Autor').css('border-color', 'lightgrey');
    $('#Editora').css('border-color', 'lightgrey');
    $('#anoPublicacao').css('border-color', 'lightgrey');
    
}
//metodo para validacao  
function validate() {
    var isValid = true;
    if ($('#Name').val().trim() == "") {
        $('#Name').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Name').css('border-color', 'lightgrey');
    }

    if ($('#Autor').val().trim() == "") {
        $('#Autor').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Autor').css('border-color', 'lightgrey');
    }


    if ($('#Editora').val().trim() == "") {
        $('#Editora').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Editora').css('border-color', 'lightgrey');
    }
    if ($('#anoPublicacao').val().trim() == "") {
        $('#anoPublicacao').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#anoPublicacao').css('border-color', 'lightgrey');
    }


    return isValid;
} 