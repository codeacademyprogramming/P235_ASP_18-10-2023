

$(document).ready(function () {
    $(function () {
        $(".fold-table tr.view").on("click", function () {
            if ($(this).hasClass("open")) {
                $(this).removeClass("open").next(".fold").removeClass("open");
            } else {
                $(".fold-table tr.view").removeClass("open").next(".fold").removeClass("open");
                $(this).addClass("open").next(".fold").addClass("open");
            }
        });
    });
    //toastr["info"]("Once Mehsul Secin")

    toastr.options = {
        "closeButton": false,
        "debug": false,
        "newestOnTop": false,
        "progressBar": false,
        "positionClass": "toast-top-right",
        "preventDuplicates": false,
        "onclick": null,
        "showDuration": "300",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    }

    let infoToaster = $('#infoToaster');
    if (infoToaster.val() != undefined && infoToaster.val().length > 0)
    {
        toastr["info"](infoToaster.val());
    }

    let successToaster = $('#successToaster');

    if (successToaster.val() != undefined && successToaster.val().length > 0) {
        toastr["success"](successToaster.val());
    }

    $('.editAddressBtn').click(function (e) {
        e.preventDefault();

        $('.addAddressBtn').addClass('d-none');
        $('.addressContainer').addClass('d-none');
        $('.editAddressForm').removeClass('d-none');

        let url = $(this).attr('href');
        fetch(url)
            .then(res => res.text())
            .then(data => {
                $('.editAddressForm').html(data);
            })
    })

    $('.addAddressBtn').click(function (e) {
        e.preventDefault();

        $('.addressForm').removeClass('d-none');
        $('.addAddressBtn').addClass('d-none');
        $('.addressContainer').addClass('d-none');
    })

    $('.goBackBtn').click(function (e) {
        e.preventDefault();

        $('.addressForm').addClass('d-none');
        $('.addAddressBtn').removeClass('d-none');
        $('.addressContainer').removeClass('d-none');
    })

    $('#searchInput').keyup(function () {
        if ($(this).val().trim().length == 0) {
            $('#searchBody').html('');
        }
    })

    $('#searchBtn').click(function (e) {
        e.preventDefault();

        let search = $('#searchInput').val().trim();
        let categoryId = $('#categoryId').val();

        let searchUrl = 'product/search?search=' + search + '&categoryId=' + categoryId

        if (search.length >= 3)
        {
            //let items = '';
            fetch(searchUrl)
                .then(res => res.text())
                .then(data => {
                    console.log(data);


                    $('#searchBody').html(data)

                    //    Old Partial
                    //for (var i = 0; i < data.length; i++) {

                        //let item = `<a class="d-block" href="#">
                        //                        <li class="d-flex justify-content-between align-items-center">
                        //                            <img style="width:100px" src="/assets/images/product/${data[i].mainImage}"/>
                        //                            <p>${data[i].title}</p>
                        //                            <span>${data[i].price}$</span>
                        //                        </li>
                        //                    </a>`;

                    //    items += item
                    //}
                    //console.log(items + ' salam Tahir');
                })

            
        }

        console.log(search + ' ' + categoryId);
    })

    //$(document).on('click', '.modalBtn', function myfunction() {

    //})

    $('.modalBtn').click(function (e) {
        e.preventDefault();

        let url = $(this).attr('href');

        fetch(url)
            .then(res => res.text())
            .then(data => {
                $('.modal-content').html(data)
                $('.quick-view-image').slick({
                    slidesToShow: 1,
                    slidesToScroll: 1,
                    arrows: false,
                    dots: false,
                    fade: true,
                    asNavFor: '.quick-view-thumb',
                    speed: 400,
                });

                $('.quick-view-thumb').slick({
                    slidesToShow: 4,
                    slidesToScroll: 1,
                    asNavFor: '.quick-view-image',
                    dots: false,
                    arrows: false,
                    focusOnSelect: true,
                    speed: 400,
                });
            })

    })

    $('.addBasket').click(function (e) {
        e.preventDefault();

        let url = $(this).attr('href');

        fetch(url)
            .then(res => res.text())
            .then(data => {
                $('.header-cart').html(data);
            })
    })

    $(document).on('click', '.loadMoreBtn', function (e) {
        e.preventDefault();

        let url = $(this).attr('href');
        let pageIndex = $(this).data("pageindex");
        let totalPage = $(this).data("maxpage");

        if (pageIndex > 0 && pageIndex < totalPage) {
            fetch(url + '?pageIndex=' + pageIndex)
                .then(res => res.text())
                .then(data => {
                    $('.productContainer').append(data);
                })
        } else if (pageIndex == totalPage) {
            fetch(url + '?pageIndex=' + pageIndex)
                .then(res => res.text())
                .then(data => {
                    $('.productContainer').append(data);
                })

            $('.loadMoreBtn').remove();
        }
        pageIndex++;
        console.log(pageIndex);
        $('.loadMoreBtn').data("pageindex", pageIndex);
    })
})