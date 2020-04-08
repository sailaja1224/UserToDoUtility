$(function () {
    $(".x-mk-task").unbind('click').on('click', function () {

        var url = '';
        // Checking whether FormData is available in browser  
        if (window.FormData !== undefined) {
            var task = {
                ID: -1,
                ToDoName: $('.tasktitle').val(),
                DueDate: $('.taskduedt').val(),
                Status: false,
                IsDeleted: false
            }

            if ($('.taskid').val() == '') {
                url = 'api/Task/Save';
            }
            else {
                task.ID = $('.taskid').val();
                url = 'api/Task/Update';
            }

            $.ajax({
                url: url,
                type: 'POST',
                data: JSON.stringify(task),
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    window.location.reload();
                },
                error: function () {
                    alert("error");
                }
            });
        } else {
            alert("FormData is not supported.");
        }
    });

    $(".editTask").unbind('click').on('click', function () {
        $('.taskid').val($(this).closest('tr').attr('data-area-id'));
        $('.tasktitle').val($(this).closest('tr').find('.tdTaskTitle')[0].innerText);
        $('.taskduedt').val($(this).closest('tr').find('.tdDueDt')[0].innerText);
    });

    $(".deleteTask").unbind('click').on('click', function () {
        var id = $(this).closest('tr').attr('data-area-id');
        var url = 'api/Task/Delete/' + id;

        swal({
            title: "Are you sure?",
            text: "Are you sure to delete this task?",
            icon: "warning",
            buttons: true,
            dangerMode: true,
        })
            .then((willDelete) => {
                if (willDelete) {
                    $.ajax({
                        url: url,
                        type: 'DELETE',
                        success: function (data) {
                            //swal(data.Message);
                            window.location.reload();
                        },
                        error: function () {
                            swal(data.Message);
                        }
                    });
                }
            });
    });

    $(".completeTask").unbind('click').on('click', function () {
        var id = $(this).closest('tr').attr('data-area-id');
        var url = 'api/Task/CompleteTask/' + id;

        swal({
            title: "Are you sure?",
            text: "Completed this task?",
            icon: "warning",
            buttons: true,
            dangerMode: true,
        })
            .then((willDelete) => {
                if (willDelete) {
                    $.ajax({
                        url: url,
                        type: 'PUT',
                        success: function (data) {
                            //swal(data.Message);
                            window.location.reload();
                        },
                        error: function () {
                            swal(data.Message);
                        }
                    });
                }
            });
    });

    //function ReloadTasks() {
    //    var url = 'api/Task/GetTasks/';
    //    $.ajax({
    //        url: url,
    //        type: 'GET',
    //        dataType: 'json', // added data type
    //        success: function (res) {
    //            console.log(res);
    //            alert(res);
    //        }
    //    });
    //}
})
