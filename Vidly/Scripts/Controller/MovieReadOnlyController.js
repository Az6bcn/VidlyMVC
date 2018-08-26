$(function () {

    $(document).ready(function () {
        // get the movies table refrence and output it has a datatable
        table = $("#movies").DataTable({
            ajax: {
                url: '/api/movies/GetMovies',
                dataSrc: ''
            },
            columns: [
                {
                    data: "Name"
                },
                {
                    data: "Genre.Name"
                }
            ]
        });
    });
})