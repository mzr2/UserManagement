//const judul = document.getElementById('judul');
//judul.innerHTML = "Ganti Judul";

//const judul = document.querySelector("#judul");
//judul.style.backgroundColor = 'blue';

//const li = document.querySelector("li:nth-child(3)");

//const p = document.querySelectorAll("p")[0];
//p.style.backgroundColor = 'cyan';
//const p = document.querySelectorAll("p");
//for (let i = 0; i < p.length; i++) {
//    if (i%2==0) {
//        p[i].style.backgroundColor = 'cyan';
//    } else {
//        p[i].style.backgroundColor = 'red';
//    }
//}

//const p4 = document.querySelector(".b p");
//console.log(p4.getAttribute("id"));
//console.log(p4.setAttribute("class","warna"));

//function loadContent() {
//    var xhr = new XMLHttpRequest();
//    var url = "https://localhost:44338/API/Accounts/UserData";
//    xhr.onreadystatechange = function () {
//        if (this.readyState == 4 && this.status == 200) {
//            document.getElementById("userdata").innerHTML = this.responseText;
//        }
//    };
//    xhr.open("GET", url, true);
//    xhr.send();
//    //$("#result").load("https://localhost:44338/API/Accounts/UserData")[0];
//}

function loadJSON(callback) {

    var xobj = new XMLHttpRequest();
    xobj.overrideMimeType("application/json");
    xobj.open('GET', "https://localhost:44338/API/Accounts/UserData", true); // Replace 'my_data' with the path to your file
    xobj.onreadystatechange = function () {
        if (xobj.readyState == 4 && xobj.status == "200") {
            // Required use of an anonymous callback as .open will NOT return a value but simply returns undefined in asynchronous mode
            callback(xobj.responseText);
        }
    };
    xobj.send(null);
}

var datas = [];

function init() {
    loadJSON(function (response) {
        // Parse JSON string into object
        var actual_JSON = JSON.parse(response);
        var string = JSON.stringify(actual_JSON);

        actual_JSON.forEach(element => {
            datas.push(element);
            currencyList.push(element.symbol);
        });

        console.log(datas);

        document.getElementById("files").innerHTML = string;
        var ele = document.getElementById('sel');
        for (var i = 0; i < datas.length; i++) {
            // POPULATE SELECT ELEMENT WITH JSON.
            ele.innerHTML = ele.innerHTML +
                '<div>' + datas[i]['FirstName'] + datas[i]['LastName'] + '</div>';
            //'<option value="' + datas[i]['symbol'] + '">' + datas[i]['name'] + '</option>';
        }

    });
}

//var buttonChangeColor = document.querySelector('.btnBg');
//buttonChangeColor.onclick = changeColor;

$('.btnBg').click(function () {
    //changeColor();
    $('body').css('background-color', 'blue');
});

function changeColor() {
    var warna = [
        "red",
        "blue",
        "cyan",
        "orange",
        "white",
        "green"
    ];

    var num = Math.floor(Math.random() * warna.length);
    document.body.style.backgroundColor = warna[num];
}

var status = 0;

function addCSS() {
    if (status == 0) {
        var main = document.getElementsByTagName('main')[0].getElementsByTagName('div');
        for (var i = 0; i < main.length; i++) {
            main[i].style.backgroundColor = 'orange';
            main[i].style.border = "1px solid black";
        }
        status = 1;
    } else {
        var main = document.getElementsByTagName('main')[0].getElementsByTagName('div');
        for (var i = 0; i < main.length; i++) {
            main[i].style.backgroundColor = 'white';
            main[i].style.border = "0px";
        }
        status = 0;
    }
    //var main = document.querySelector("main .col");
    
    
}

//var btn = document.getElementById('btnColor');
//btn.addEventListener("mouseover", mouseOver);
//btn.addEventListener("mouseout", mouseOut);

//function mouseOver() {
//    document.getElementById("txt").innerHTML += "Mouse over Change Color button <br>";
//}
//function mouseOut() {
//    document.getElementById("txt").innerHTML += "Mouse out from Change Color button <br>";
//}

var dataStatus = 0;

$('.btnData').click(function () {
    if (dataStatus == 0) {
        $.ajax({
            url: "https://localhost:44338/API/Accounts/UserData",
            type: "GET",
            dataType: "json",
            success: function (result) {
                console.log(result);
                var th = '<th style:"border= 1px solid black;">First Name</th><th style="border: 1px solid black;">Last Name</th><th style="border: 1px solid black;">Email</th>';
                $('#table').append(th);
                for (var i = 0; i < result.length; i++) {
                    var row = '';
                    var col = '';
                    row += '<tr>';
                    col += '<td style="border: 1px solid black;">' + result[i].firstName + '</td>';
                    col += '<td style="border: 1px solid black;">' + result[i]['lastName'] + '</td>';
                    col += '<td style="border: 1px solid black;">' + result[i]['email'] + '</td>';
                    row += col;
                    row += '</tr>';
                    $('#table').append(row);
                }
            }
        });
        dataStatus = 1;
    } else {
        $('#table').empty();
        dataStatus = 0;
    }
});

$.ajax({
    //url: "https://swapi.dev/api/people/"
    url: "https://pokeapi.co/api/v2/pokemon/"
}).done((result) => {
    console.log(result);
    //console.log(result.results);
    var text = "";
    $.each(result.results, function (key, val) {
        text += `<tr>
                    <td>${val.name}</td>
                    <td><button type="button" id="tes" class="btn btn-primary tes" id="buttonDetail" data-toggle="modal" value="${val.url}" data-body="${val.url}" data-url="${val.url}" onclick="dataPokemon('${val.url}')">Detail</button></td>
                </tr>`
        //text += `<li>${val.name}</li>`
    });
    $("#listpokemon").html(text);
}).fail((error) => {
    console.log(error);
});


//$('.tes').on('click', function () {
//    var link = $(this).val();
//    $.ajax({
//        url: link
//    }).done((result) => {
//        console.log(result);
//    }).fail((error) => {
//        console.log(error);
//    });
//});

function dataPokemon(link) {
    $.ajax({
        url: link
        //url: link
    }).done((result) => {
        var ability = "";
        console.log(result);
        $.each(result.abilities, function (key, val) {
            ability += `<li>${val.ability.name}</li>`;
        });
        
        var text = `<ul>
                        <li>
                            Name : ${result.name}
                        </li>
                        <li>
                            Ability : 
                            <ul>`+
                                ability
                            +`</ul>
                        </li>
                        <li>
                            Movement : ${result.moves[0].move.name}
                        </li>
                        <li>
                            Species : ${result.species.name}
                        </li>
                        <li>
                            Weight : ${result.weight}
                        </li>
                        <li>
                            Sprites :
                            <img src="${result.sprites.front_default}">
                        </li>
                    </ul>`
        $('#exampleModalLabel').html(result.name);
        $('.modal-body').html(text);
        $('#exampleModal').modal('show');
    }).fail((error) => {
        console.log(error);
    });
}

$.ajax({
    url: "https://localhost:44338/API/Accounts/UserData"
}).done((result) => {
    console.log(result);
    //console.log(result.results);
    var text = "";
    $.each(result, function (key, val) {
        text += `<tr>
                    <td>${val.firstName} ${val.lastName}</td>
                    <td><button type="button" id="tes" class="btn btn-primary tes" id="buttonDetail" data-toggle="modal" value="${val.NIK}" data-body="${val.NIK}" data-url="${val.NIK}" onclick="dataUser('${val.nik}')">Detail</button></td>
                </tr>`
        //text += `<li>${val.name}</li>`
    });
    $("#listuser").html(text);
}).fail((error) => {
    console.log(error);
});

function dataUser(nik) {
    $.ajax({
        url: "https://localhost:44338/API/Accounts/Profile/" + nik
    }).done((result) => {
        var ability = "";
        console.log(result);
        var text = `<ul>
                        <li>
                            Name      : ${result.firstName} ${result.lastName} 
                        </li>
                        <li>
                            NIK       : ${result.nik} 
                        </li>
                        <li>
                            Phone     : ${result.phone}
                        </li>
                        <li>
                            Birthdate : ${result.birthDate}
                        </li>
                        <li>
                            Salary    : ${result.salary} 
                        </li>
                        <li>
                            Email     : ${result.email} 
                        </li>
                        <li>
                            Degree     : ${result.degree} 
                        </li>
                        <li>
                            GPA        : ${result.gpa} 
                        </li>
                        <li>
                            University : ${result.universityName} 
                        </li>
                    </ul>`
        $('#exampleModalLabel').html(result.firstName + ' ' + result.lastName);
        $('.modal-body').html(text);
        $('#exampleModal').modal('show');
    }).fail((error) => {
        console.log(error);
    });
}

$(document).ready(function () {
    var table = $('#example').DataTable({
        dom: 'Bfrtip',
        ajax: {
            "url": "https://localhost:44338/API/Accounts/UserData",
            "datatype": "json",
            "dataSrc": ""
        },
        columns: [
            { data: null, "searchable": false, orderable: false, "targets": 0 },
            { data: 'firstName' },
            { data: 'lastName' },
            { data: 'nik' },
            {
                data: 'phone',
                render: function (data, type, row) {
                    return '+62' + data.substring(1, data.length);
                }
            },
            { data: 'birthDate' },
            { data: 'salary' },
            { data: 'email' },
            { data: 'degree' },
            { data: 'gpa'},
            { data: 'universityName' },
            { data: null, defaultContent: "<button>Detail</button>", targets: -1, "orderable": false}
        ],
        buttons: [
            {
                extend: 'copyHtml5',
                exportOptions: {
                    columns: [1, 2, 3, 4, 5, 6, 7, 8, 9]
                },
                orientation: 'landscape'
            },
            {
                extend: 'excelHtml5',
                exportOptions: {
                    columns: [1, 2, 3, 4, 5, 6, 7, 8, 9]
                },
                orientation: 'landscape'
            },
            {
                extend: 'csvHtml5',
                exportOptions: {
                    columns: [1, 2, 3, 4, 5, 6, 7, 8, 9]
                },
                orientation: 'landscape'
            },
            {
                extend: 'pdfHtml5',
                exportOptions: {
                    columns: [1, 2, 3, 4, 5, 6, 7, 8, 9]
                },
                orientation: 'landscape'
            }
        ]
    });

    $('#example tbody').on('click', 'button', function () {
        var data = table.row($(this).parents('tr')).data();
        //alert(data.firstName + " " + data.lastName + "'s salary is: " + data.salary);
        dataUser(data.nik);
    });
    table.on('order.dt search.dt', function () {
        table.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
            cell.innerHTML = i + 1;
        });
    }).draw();
});

$(document).ready(function () {
    var t = $("#mytable").DataTable({
        "ajax": {
            "url" : "https://pokeapi.co/api/v2/pokemon",
            "datatype": "json",
            "dataSrc" : "results"
        },
        "order": [[1, 'asc']],
        "columns": [
            { "data": null, "searchable": false, "orderable": false, "targets": 0},
            { "data": "name" },
            { "data": "url" }
        ]
    });
    t.on('order.dt search.dt', function () {
        t.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
            cell.innerHTML = i + 1;
        });
    }).draw();
});

