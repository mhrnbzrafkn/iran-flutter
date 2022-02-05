function UploadImage() {
    let photo = document.getElementById("image-file").files[0];

    let formData = new FormData();

    formData.append('file', photo);

    $.ajax({
        url: "/api/Upload/banner",
        type: "POST",
        data: formData,
        contentType: false,
        processData: false,
        success: function (data) {
            console.log("Image Successfully Uploaded...")
        },
        error: function (data) {
            console.log("Failed To Upload Image...")
        }
    });
}
function SetCover() {
    var Image_Input = document.getElementById("image-file");

    var reader = new FileReader();

    reader.onload = function (e) {
        $('#defaultCover').attr('src', e.target.result);
    }
    reader.readAsDataURL(Image_Input.files[0]);
}