function copytText(_this) {
    var copyText = $(_this)?.length > 0 ? $(_this)[0] : null;
    if (copyText != null) {
        copyText.select();
        copyText.setSelectionRange(0, 99999);
        navigator.clipboard
            .writeText(copyText.value)
            .then(() => {
                alert("successfully copied");
            })
            .catch(() => {
                alert("something went wrong");
            });
    } else {

    }
}