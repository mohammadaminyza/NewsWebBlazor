function OnDocumentInit() {
    jQuery('[data-toggle="tooltip"]').tooltip();

    jQuery('.main-slider').owlCarousel({
        rtl: true,
        loop: true,
        margin: 8,
        nav: true,
        autoplay: true,
        autoplayTimeout: 5000,
        autoplayHoverPause: true,
        responsive: {
            0: {
                items: 1
            },
            600: {
                items: 1
            },
            1000: {
                items: 1
            }
        }
    });
}

function SweetAlertConfirm(title, text, confirmText, deniedText) {
    return swal({
        title: title,
        text: text,
        icon: "warning",
        buttons: true,
        dangerMode: true,
    })
        .then((willDelete) => {
            if (willDelete) {
                swal(confirmText, {
                    icon: "success",
                });

                return true;
            } else {
                swal(deniedText);

                return false;
            }
            return false;
        });
}

function SweetAlert(text, mode) {
    swal(text, {
        icon: mode,
    });
}