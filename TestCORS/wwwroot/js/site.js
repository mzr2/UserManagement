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
        //url: "https://localhost:44338/API/Accounts/Profile/" + nik
        url: "/Accounts/GetUserDataDetail?Nik=" + nik
    //}).done((result) => {
    }).done((result) => {
        console.log(result);
        //var result = resultUser.person;
        //console.log(result);
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
        $('#modal-body-detail').html(text);
        $('#exampleModal').modal('show');
    }).fail((error) => {
        console.log(error);
    });
}

$(document).ready(function () {
    var table = $('#example').DataTable({
        dom: 'lBfrtip',
        ajax: {
            "url": "/Accounts/GetUserData",
            //"url": "https://localhost:44312/Accounts/GetAll",
            "datatype": "json",
            "dataSrc": ""
        },
        //columnDefs: [
        //    { "targets": 0, "order": 'applied', "search": 'applied'}
        //],
        columns: [
            {
                data: null, "searchable": false, orderable: false, "targets": 0, render: function (data, type, row, meta) {
                    return meta.row+1;
                }
            },
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
            //{ data: null, defaultContent: '<button class="btn btn-primary" id="detailbutton">Detail</button>|<button class="btn btn-primary" id="deletebutton">Delete</button>|<button class="btn btn-primary" id="editbutton">Edit</button>', targets: -1, "orderable": false}
            { data: null, defaultContent: '<div class="btn-group mr-2" role="group" aria-label="First group"><button class="btn btn-primary" id="detailbutton"><i class="fas fa-eye"></i></button>|<button class="btn btn-danger" id="deletebutton"><i class="fas fa-trash"></i></button>|<button class="btn btn-secondary" id="editbutton"><i class="fas fa-edit"></i></button></div>', targets: -1, "orderable": false}
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

    $('#example tbody').on('click', '#detailbutton', function () {
        var data = table.row($(this).parents('tr')).data();
        dataUser(data.nik);
    });

    $('#example tbody').on('click', '#deletebutton', function () {
        var data = table.row($(this).parents('tr')).data();
        Delete(data.nik);
    });

    $('#example tbody').on('click', '#editbutton', function () {
        var data = table.row($(this).parents('tr')).data();
        getbyID(data.nik);
    });
    //table.on('order.dt search.dt', function () {
    //    table.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
    //        cell.innerHTML = i + 1;
    //    });
    //}).draw();
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


//--------CREATE, UPDATE, DELETE---------------

//Get University Data
$.ajax({
    url: "https://localhost:44338/API/Universities"
}).done((result) => {
    console.log(result);
    //console.log(result.results);
    var text = "";
    $.each(result, function (key, val) {
        text += `<option value="${val.universityId}">${val.name}</option>`
        //text += `<li>${val.name}</li>`
    });
    $("#UniversityId").html(text);
}).fail((error) => {
    console.log(error);
});

function validateEmail(email) {
    const re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(email);
}

function validatePassword (password) {
    var validated = true;
    if (password.length < 8)
        validated = false;
    //if (!/\d/.test(password))
    //    validated = false;
    //if (!/[a-z]/.test(password))
    //    validated = false;
    //if (!/[A-Z]/.test(password))
    //    validated = false;
    //if (/[^0-9a-zA-Z]/.test(password))
    //    validated = false;
    return validated;
    // use DOM traversal to select the correct div for this input above
}

function addOrUpdate() {
    $(".formButton").on('click', function () {
        if ($(this).val()=='add') {
            Add();
        } else if ($(this).val() == 'update') {
            Update();
        }
    });
}

function validate() {
    var isValid = true;
    if ($('#NIK').val().trim() == "") {
        $('#NIK').css('border-color', 'Red');
        $('.NIK').html("NIK WAJIB DIISI").css('color', 'Red');
        isValid = false;
    }
    else {
        $('#NIK').css('border-color', 'lightgrey');
        $('.NIK').html("GOOD BOY").css('color', 'Green');
    }
    if ($('#FirstName').val().trim() == "") {
        $('#FirstName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#FirstName').css('border-color', 'lightgrey');
    }
    if ($('#LastName').val().trim() == "") {
        $('#LastName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#LastName').css('border-color', 'lightgrey');
    }
    if ($('#Phone').val().trim() == "") {
        $('#Phone').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Phone').css('border-color', 'lightgrey');
    }
    if ($('#BirthDate').val().trim() == "") {
        $('#BirthDate').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#BirthDate').css('border-color', 'lightgrey');
    }
    if ($('#Salary').val().trim() == "") {
        $('#Salary').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Salary').css('border-color', 'lightgrey');
    }
    if ($('#Email').val().trim() == "") {
        $('#Email').css('border-color', 'Red');
        $('.Email').html("Fill this section").css('color', 'Red');
        isValid = false;
    }
    else {
        if (validateEmail($('#Email').val())) {
            $('#Email').css('border-color', 'lightgrey');
            $('.Email').html("GOOD BOY").css('color', 'Green');
        } else {
            $('#Email').css('border-color', 'Red');
            $('.Email').html("Email must contain @").css('color', 'Red');
            isValid = false;
        }
    }
    if ($('#Password').val().trim() == "") {
        $('#Password').css('border-color', 'Red');
        $('.Password').html("Password must have atleast 8 character").css('color', 'Red');
        isValid = false;
    }
    else {
        if (validatePassword($('#Password').val())) {
            $('#Password').css('border-color', 'lightgrey');
            $('.Password').html("GOOD BOY").css('color', 'Green');
        } else {
            $('#Password').css('border-color', 'Red');
            $('.Password').html("Password must have atleast 8 character").css('color', 'Red');
            isValid = false;
        }
    }
    if ($('#Degree').val().trim() == "") {
        $('#Degree').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Degree').css('border-color', 'lightgrey');
    }
    if ($('#GPA').val().trim() == "") {
        $('#GPA').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#GPA').css('border-color', 'lightgrey');
    }
    if ($('#UniversityId').val().trim() == "") {
        $('#UniversityId').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#UniversityId').css('border-color', 'lightgrey');
    }
    return isValid;
}  

function clearTextBox() {
    document.getElementById("NIK").readOnly = false;
    $('#crudModalLabel').html("Insert New Data");
    $('#NIK').val("");
    $('.NIK').html("");
    $('#FirstName').val("");
    $('#LastName').val("");
    $('#Phone').val("");
    $('#BirthDate').val("");
    $('#Salary').val("");
    $('#Email').val("");
    $('.Email').html("");
    $('#Password').val("");
    $('.Password').html("");
    $('#Degree').val("");
    $('#GPA').val("");
    $('#UniversityId').val("");
    $('#btnUpdate').hide();
    $('#btnAdd').show();
    $('#NIK').css('border-color', 'lightgrey');
    $('#FirstName').css('border-color', 'lightgrey');
    $('#LastName').css('border-color', 'lightgrey');
    $('#Phone').css('border-color', 'lightgrey');
    $('#BirthDate').css('border-color', 'lightgrey');
    $('#Salary').css('border-color', 'lightgrey');
    $('#Email').css('border-color', 'lightgrey');
    $('#Password').css('border-color', 'lightgrey');
    $('#passwordDiv').css('display', 'block');
    $('#Degree').css('border-color', 'lightgrey');
    $('#GPA').css('border-color', 'lightgrey');
    $('#UniversityId').css('border-color', 'lightgrey');
}

    function Add() {
        var res = validate();
        if (res == false) {
            return false;
        }
        //var empObj = {
        //    NIK: $('#NIK').val(),
        //    FirstName: $('#FirstName').val(),
        //    LastName: $('#LastName').val(),
        //    Phone: $('#Phone').val(),
        //    BirthDate: $('#BirthDate').val(),
        //    Salary: $('#Salary').val(),
        //    Email: $('#Email').val(),
        //    Password: $('#Password').val(),
        //    Degree: $('#Degree').val(),
        //    GPA: $('#GPA').val(),
        //    UniversityId: $('#UniversityId').val()
        //};
        var obj = new Object();
        obj.NIK = $('#NIK').val();
        obj.FirstName = $('#FirstName').val();
        obj.LastName = $('#LastName').val();
        obj.Phone = $('#Phone').val();
        obj.BirthDate = $('#BirthDate').val();
        obj.Salary = $('#Salary').val();
        obj.Email = $('#Email').val();
        obj.Password = $('#Password').val();
        obj.Degree = $('#Degree').val();
        obj.GPA = $('#GPA').val();
        obj.UniversityId = $('#UniversityId').val();
        $.ajax({
            url: "https://localhost:44338/API/Accounts/Register",
            data: JSON.stringify(obj),
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                console.log(result);
                //alert(result);
                $('#crud').modal('hide');
                Swal.fire({
                    icon: 'success',
                    title: 'Success',
                    text: 'Insert Data Berhasil',
                    footer: '<a href>GOOD</a>'
                })
                $('#example').DataTable().ajax.reload();
            },
            error: function (errormessage) {

                alert(errormessage.responseText);
            }
        });
}
function Update() {
        var res = validate();
        if (res == false) {
            return false;
        }
        var person = {
            NIK: $('#NIK').val(),
            FirstName: $('#FirstName').val(),
            LastName: $('#LastName').val(),
            Phone: $('#Phone').val(),
            BirthDate: $('#BirthDate').val(),
            Salary: $('#Salary').val(),
            Email: $('#Email').val(),
        };

        var Education = {};
        $.ajax({
            url: "https://localhost:44338/API/Profilings/" + person.NIK
        }).done((result) => {
            console.log(result.educationId);
            Education = {
                EducationId: result.educationId,
                Degree: $('#Degree').val(),
                GPA: $('#GPA').val(),
                UniversityId: $('#UniversityId').val(),
            }
        });

        $.ajax({
            url: "https://localhost:44338/API/Persons",
            data: JSON.stringify(person),
            type: "PUT",
            contentType: "application/json;charset=utf-8",
        }).done(() => {
            $.ajax({
                url: "https://localhost:44338/API/Educations",
                data: JSON.stringify(Education),
                type: "PUT",
                contentType: "application/json;charset=utf-8",
            }).done((resultEdu) => {
                $('#crud').modal('hide');
                Swal.fire(
                    'Updated',
                    'User data has been updated.',
                    'success'
                )
                $('#example').DataTable().ajax.reload();
            }).fail((errorEdu) => {
                $('#crud').modal('hide');
                Swal.fire(
                    'Error',
                    'User data failed to update.',
                    'error'
                )
                $('#example').DataTable().ajax.reload();
            });
        }).fail((errorPerson) => {
            $('#crud').modal('hide');
            Swal.fire(
                'Error',
                'User data failed to update.',
                'error'
            )
            $('#example').DataTable().ajax.reload();
        });
    }  
//$(document).ready(function () {
//    $('#btnAdd').click(function () {
//        Add();
//    });

//    $('#btnUpdate').click(function () {
//        Update();
//    });
//});

function Delete(ID) {

    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            var profiling = "";
            $.ajax({
                url: "https://localhost:44338/API/Profilings/" + ID
            }).done((result) => {
                profiling = result.educationId;
            });

            $.ajax({
                url: "https://localhost:44338/API/Accounts/" + ID,
                type: "DELETE"
            }).done((result) => {
                $.ajax({
                    url: "https://localhost:44338/API/Persons/" + ID,
                    type: "DELETE"
                }).done((result) => {
                    $.ajax({
                        url: "https://localhost:44338/API/Educations/" + profiling,
                        type: "DELETE"
                    }).done((result) => {
                        Swal.fire(
                            'Deleted!',
                            'User data has been deleted.',
                            'success'
                        )
                        $('#example').DataTable().ajax.reload();
                    }).fail((error) => {

                    });
                }).fail((error) => {

                });
            }).fail((error) => {

            });
            
        }
    })

    //var ans = confirm("Are you sure you want to delete this Record?");
    //if (ans) {
    //    var profiling = "";
    //    $.ajax({
    //        url: "https://localhost:44338/API/Profilings/" + ID
    //    }).done((result) => {
    //        profiling = result.educationId;
    //    });
    //    $.ajax({
    //        url: "https://localhost:44338/API/Accounts/" + ID,
    //        type: "DELETE"
    //    }).done((result) => {
    //        $.ajax({
    //            url: "https://localhost:44338/API/Persons/" + ID,
    //            type: "DELETE"
    //        }).done((result) => {
    //            $.ajax({
    //                url: "https://localhost:44338/API/Educations/" + profiling,
    //                type: "DELETE"
    //            }).done((result) => {
    //                alert("Data Terhapus");
    //                $('#example').DataTable().ajax.reload();
    //            }).fail((error) => {

    //            });
    //        }).fail((error) => {

    //        });
    //    }).fail((error) => {

    //    });
    //}
}

function getbyID(ID) {
    $('#NIK').css('border-color', 'lightgrey');
    $('#FirstName').css('border-color', 'lightgrey');
    $('#LastName').css('border-color', 'lightgrey');
    $('#Phone').css('border-color', 'lightgrey');
    $('#BirthDate').css('border-color', 'lightgrey');
    $('#Salary').css('border-color', 'lightgrey');
    $('#Email').css('border-color', 'lightgrey');
    //$('#Password').css('border-color', 'lightgrey').css('display', 'none');
    $('#passwordDiv').css('display', 'none');
    $('#Degree').css('border-color', 'lightgrey');
    $('#GPA').css('border-color', 'lightgrey');
    $('#UniversityId').css('border-color', 'lightgrey');
    $.ajax({
        url: "https://localhost:44338/API/Accounts/Profile/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#crudModalLabel').html("Edit Data");
            $('#NIK').val(result.nik).attr('readonly', 'true');
            $('#FirstName').val(result.firstName);
            $('#LastName').val(result.lastName);
            $('#Phone').val(result.phone);
            $('#Password').val('12345678');
            var stringdate = JSON.stringify(result.birthDate);
            var arrydate = stringdate.split("-");
            var year = arrydate[0].substring(1, 5);
            var month = arrydate[1];
            var day = arrydate[2].substring(0, 2);
            var today = year + "-" + month + "-" + (day);
            $('#BirthDate').val(today);
            $('#Salary').val(result.salary);
            $('#Email').val(result.email);
            //$('#Password').val();
            $('#Degree').val(result.degree);
            $('#GPA').val(result.gpa);
            $('#UniversityId').val(result.universityId);

            $('#crud').modal('show');
            $('#btnUpdate').show();
            $('#btnAdd').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}

//---------------CHART--------------------

$(document).ready(function () {
    var ctx = document.getElementById('myChart').getContext('2d');
    var myChart = new Chart(ctx, {
        type: 'pie',
        data: {
            labels: [
                'Red',
                'Blue',
                'Yellow'
            ],
            datasets: [{
                label: 'My First Dataset',
                data: [300, 50, 100],
                backgroundColor: [
                    'rgb(255, 99, 132)',
                    'rgb(54, 162, 235)',
                    'rgb(255, 205, 86)'
                ],
                hoverOffset: 4
            }]
        }
    });
});
