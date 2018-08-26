$(function () {
    var table;

    $(document).ready(function () {
        // get the movies table refrence and output it has a datatable
        table = $("#movies").DataTable({
            ajax: {
                url: '/api/movies/GetMovies',
                dataSrc: ''
            },
            columns: [
                {
                    data: "Name",
                    render: function (data, type, movie) {
                        // return clickable link ==> goes to edit movie
                        return "<a href='/movies/Edit/" + movie.Id + "'>" + movie.Name + "</a>";
                    }
                },
                {
                    data: "Genre.Name"
                },

                {
                    data: "Id",
                    render: function (data) {
                        return "<button class='btn-link js-delete' data-movie-id=" + data + "> Delete </button>";
                    }
                }

            ]
        });
    });


    $(document).on('click', movieModel.movieDelete, function () {
        // get the id of the movie to delete
        var movieID = $(this).attr('data-movie-id');
        // get the row
        var row = $(this).parents('tr');

        bootbox.confirm("Are you sure you want to delete this movie?", function (result) {
            if (result) {
                movieModel.Delete(movieID, row, table);
            }
        })
       

    })
})