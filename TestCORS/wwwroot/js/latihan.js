//arrow function
const hitung = (num1, num2) => num1 + num2;
console.log(hitung(1, 2));

const animals = [
    { name: "taro", species: "cat", kelas: { name: "mamalia"}},
    { name: "budi", species: "dog", kelas: { name: "vertebrata"}},
    { name: "anto", species: "cat", kelas: { name: "mamalia" } },
    { name: "yayan", species: "cat", kelas: { name: "mamalia" } },
    { name: "agus", species: "dog", kelas: { name: "vertebrata"}},
    { name: "rangga", species: "cat", kelas: { name: "mamalia"}}
]
var showStat = 0;
$('.allAnimals').click(function () {
    if (showStat == 0) {
        var th = '<th style:"border= 1px solid black;">Name</th><th style="border: 1px solid black;">Species</th><th style="border: 1px solid black;">Kelas</th>';
        $('#table').append(th);
        for (var i = 0; i < animals.length; i++) {
            var row = '';
            var col = '';
            row += '<tr>';
            col += '<td style="border: 1px solid black;">' + animals[i].name + '</td>';
            col += '<td style="border: 1px solid black;">' + animals[i].species + '</td>';
            col += '<td style="border: 1px solid black;">' + animals[i].kelas.name + '</td>';
            row += col;
            row += '</tr>';
            $('#table').append(row);
        }
        showStat = 1;
    } else {
        $('#table').empty();
        showStat = 0;
    }
});

let Cat = [];
for (var i = 0; i < animals.length; i++) {
    if (animals[i].species === 'cat') {
        Cat.push(animals[i]);
    }
}
console.log(Cat);
$('.catOnly').click(function () {
    if (showStat == 0) {
        var th = '<th style:"border= 1px solid black;">Name</th><th style="border: 1px solid black;">Species</th><th style="border: 1px solid black;">Kelas</th>';
        $('#table').append(th);
        for (var i = 0; i < Cat.length; i++) {
            var row = '';
            var col = '';
            row += '<tr>';
            col += '<td style="border: 1px solid black;">' + Cat[i].name + '</td>';
            col += '<td style="border: 1px solid black;">' + Cat[i].species + '</td>';
            col += '<td style="border: 1px solid black;">' + Cat[i].kelas.name + '</td>';
            row += col;
            row += '</tr>';
            $('#table').append(row);
        }
        showStat = 1;
    } else {
        $('#table').empty();
        showStat = 0;
    }
});
console.log(animals);

$('.nonMamals').click(function () {
    if (showStat == 0) {
        for (var i = 0; i < animals.length; i++) {
            if (animals[i].kelas.name != 'mamalia') {
                animals[i].kelas.name = 'non-mamalia';
            }
        }
        var th = '<th style:"border= 1px solid black;">Name</th><th style="border: 1px solid black;">Species</th><th style="border: 1px solid black;">Kelas</th>';
        $('#table').append(th);
        for (var i = 0; i < animals.length; i++) {
            var row = '';
            var col = '';
            row += '<tr>';
            col += '<td style="border: 1px solid black;">' + animals[i].name + '</td>';
            col += '<td style="border: 1px solid black;">' + animals[i].species + '</td>';
            col += '<td style="border: 1px solid black;">' + animals[i].kelas.name + '</td>';
            row += col;
            row += '</tr>';
            $('#table').append(row);
        }
        showStat = 1;
    } else {
        $('#table').empty();
        showStat = 0;
    }
});

//for (var i = 0; i < animals.length; i++) {
//    if (animals[i].kelas.name != 'mamalia') {
//        animals[i].kelas.name = 'non-mamalia';
//    }
//}

//const animalNew = animals.map((animal) =>
//    );
console.log(animals);


//-------------------------Latihan API-----------------------
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
            + `</ul>
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