let stay = 30000;
let fadeOut = 1000;
$(document).ready(Disappear);

// Function deciding how long the messagebox will be shown when performing a registration.
function Disappear() {
    $('#PopupBox').fadeTo(stay, fadeOut).slideUp(fadeOut, function () {
        $('#PopupBox').slideUp(fadeOut);
    });
}