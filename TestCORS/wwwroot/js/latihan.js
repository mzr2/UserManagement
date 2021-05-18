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