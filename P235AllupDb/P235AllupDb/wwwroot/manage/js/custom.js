$(document).ready(function () {
    let isMain = $('#IsMain').is(':checked');
    if (isMain === true) {
        $('.imgContainer').removeClass('d-none');
        $('.parentContainer').addClass('d-none');
    } else {
        $('.imgContainer').addClass('d-none');
        $('.parentContainer').removeClass('d-none');
    }


    $('#IsMain').click(function () {
        let isMain = $(this).is(':checked');
        if (isMain === true)
        {
            $('.imgContainer').removeClass('d-none');
            $('.parentContainer').addClass('d-none');
        } else
        {
            $('.imgContainer').addClass('d-none');
            $('.parentContainer').removeClass('d-none');
        }
    })

    $(document).on('click', '.deleteimagebtn', function (e) {
        e.preventDefault();

        let url = $(this).attr('href');

        fetch(url)
            .then(res => res.text())
            .then(data => {
                console.log(data)
                $('.imageContainer').html(data);
            })
    })

    $(document).on('click', '.setActiveBtn', function (e) {
        e.preventDefault();

        Swal.fire({
            title: 'Are you sure?',
            text: "You won't be able to revert this!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, Change Active Status!'
        }).then((result) => {
            if (result.isConfirmed) {
                let url = $(this).attr('href');

                fetch(url)
                    .then(res => res.text())
                    .then(data => {
                        $('.listContainer').html(data);
                    })

                Swal.fire(
                    'Changed Active Status!',
                    'Your file has been deleted.',
                    'success'
                )
            }
        })

    })

    $(document).on('click', '.resetPasswordBtn', function (e) {
        e.preventDefault();

        Swal.fire({
            title: 'Are you sure?',
            text: "You won't be able to revert this!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, Reset it!'
        }).then((result) => {
            if (result.isConfirmed) {
                let url = $(this).attr('href');

                fetch(url)
                    .then(res => res.text())
                    .then(data => {
                        $('.listContainer').html(data);
                    })

                Swal.fire(
                    'Reseted!',
                    'Your pasword has been reseted.',
                    'success'
                )
            }
        })
    })
    
})
