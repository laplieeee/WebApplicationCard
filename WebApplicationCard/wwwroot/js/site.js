$(function () {
    $("#idCardRegister").on("submit", function () {
        var form = $(this)[0];
        if (form.checkValidity() === false) {
            event.preventDefault();
            event.stopPropagation();
        }
        form.classList.add('was-validated');
    });
});

function Step2validation() {

    var checkPic = document.getElementById("Picture").value;
    var checkIdNum = document.getElementById("IdNum").value; 
    document.getElementById("checkPic").innerHTML = "";
    let text;
    {
        if (checkPic === "") {
            text = "กรุณาใส่รูปภาพ";
        }
        else {
            text = ""
        }

        document.getElementById("checkPic").innerHTML = text;

    }
    {
        if (checkIdNum === "") {
            text = "กรุณากรอกข้อมูล";
        }
        else if (checkIdNum.match(/^[0-9]{13}$/)) {
            text = ""
        }
        else {
            text = "กรุณาระบุเลขบัตรประจำตัวประชาชน 13 หลัก"
        }

        document.getElementById("checkIdNum").innerHTML = text;
    }
   
}

