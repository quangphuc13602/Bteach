$(document).ready(function () {
    LoadMenuCha()
    LoadMenu();
});
function LoadMenu(val) {
    $.ajax({
        url: 'https://localhost:5001/api/Categories?cate=' + val,
        type: 'GET',
        success: function (rs) {
            var str = '';
            $.each(rs, function (i, item) {
                str += '<a class="dropdown-item" href="article-details.html"><span class="item-text">';
                str += rs[i]["name"];
                str += "</span></a>";
                str += '<div class="dropdown-items-divide-hr"></div>'
            });
            $('#' + val).html(str);
        }
    });
};

function LoadMenuCha() {
    $.ajax({
        url: 'https://localhost:5001/api/Categories',
        type: 'GET',
        success: function (rs) {
            var str = '';
            $.each(rs, function (i, item) {
                var xData = CountMenuCon(rs[i]["idcategory"]);
                console.log(xData.length);
                if (xData != 0) {
                    str += '<li class="nav-item dropdown">'
                        + '<a class="nav-link dropdown-toggle page-scroll nav-text" href="reading-list.html" '
                        + 'id = "navbarDropdown" role = "button" aria-haspopup="true" aria-expanded="false"> ';
                    str += rs[i]["name"];
                    str += "</a>";
                    str += '<div class="dropdown-menu" aria-labelledby="navbarDropdown" id="' + rs[i]["idcategory"] + '"></div>';
                    str += '</li>'
                    LoadMenu(rs[i]["idcategory"])
                }
                else {
                    str += '<li class="nav-item">';
                    str += '<a class="nav-link page-scroll nav-text" href = "#pricing" >';
                    str += rs[i]["name"];
                    str += '</a></li>'
                }





            });
            $('#menu').append(str);

        }
    });

};

function CountMenuCon(selector) {
    var result = false;
    $.ajax({
        type: "GET",
        url: 'https://localhost:5001/api/Categories?cate=' + selector,
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
