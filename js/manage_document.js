var listDocument;
$(document).ready(function () {
    LoadCategory();
    LoadTable(null);
});
function LoadCategory() {
    $.ajax({
        url: 'https://localhost:5001/api/Categories',
        type: 'GET',
        success: function (rs) {
            var str = '<option value="">Tất cả tài liệu</option>';
            $.each(rs, function (i, item) {
                str += "<option value='" + rs[i]["idcategory"] + "'>";
                str += rs[i]["name"];
                str += "</option>";
            });
            document.getElementById("Category").innerHTML = str;
        }
    });
};

function GetListDocumnet(selector) {
    var result = false;
    urlDoc = "";
    if (selector === null) {
        urlDoc = 'https://localhost:5001/api/Document';
    }
    else {
        urlDoc = 'https://localhost:5001/api/Document?cate=' + selector
    }
    $.ajax({
        type: "GET",
        url: urlDoc,
        data: ({ issession: 1, selector: selector }),
        dataType: "html",
        async: false,
        success: function (data) {
            var obj = JSON.parse(data);
            result = obj;
        },
        error: function () {
            alert('Error occured');
        }
    });
    return result;
}

function GetListDocumnetWithStatus(status) {
    var str = '';
    if (status != null) {
        $.each(listDocument, function (i, item) {
            if (listDocument[i]['status'] == status) {
                str += '<tr style="vertical-align: middle;">';
                str += '<th scope="row">' + i + '</th>';
                str += '<td><img src="images/description-3.png" width="50px" height="50px"></td>';
                str += '<td>Toán</td>';
                str += '<td>' + listDocument[i]["name"] + '</td>';
                var status_text = "Chưa duyệt";
                if (listDocument[i]['status']) {
                    status_text = "Đã duyệt";
                }
                str += '<td>' + status_text + '</td>';
                str += '<td><a href=""><i class="fas fa-trash"></i></a></td>';
            }
        });
    }
    else {
        $.each(listDocument, function (i, item) {
            str += '<tr style="vertical-align: middle;">';
            str += '<th scope="row">' + i + '</th>';
            str += '<td><img src="images/description-3.png" width="50px" height="50px"></td>';
            str += '<td>Toán</td>';
            str += '<td>' + listDocument[i]["name"] + '</td>';
            var status_text = "Chưa duyệt";
            if (listDocument[i]['status']) {
                status_text = "Đã duyệt";
            }
            str += '<td>' + status_text + '</td>';
            str += '<td><a href=""><i class="fas fa-trash"></i></a></td>';
        });
    }

    document.getElementById("table_body").innerHTML = str;
}

function LoadTable(val) {
    listDocument = GetListDocumnet(val);
    urlDoc = "";
    if (val === null) {
        urlDoc = 'https://localhost:5001/api/Document';
    }
    else {
        urlDoc = 'https://localhost:5001/api/Document?cate=' + val
    }
    $.ajax({

        url: urlDoc,
        type: 'GET',
        success: function (rs) {
            var str = '';
            $.each(rs, function (i, item) {
                str += '<tr style="vertical-align: middle;">';
                str += '<th scope="row">' + i + '</th>';
                str += '<td><img src="images/description-3.png" width="50px" height="50px"></td>';
                str += '<td>Toán</td>';
                str += '<td>' + rs[i]["name"] + '</td>';
                var status = "Chưa duyệt";
                if (rs[i]['status']) {
                    status = "Đã duyệt";
                }
                str += '<td>' + status + '</td>';
                str += '<td><a href=""><i class="fas fa-trash"></i></a></td>';
            });
            document.getElementById("table_body").innerHTML = str;
        }
    });
}
