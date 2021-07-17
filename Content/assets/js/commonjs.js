
//var BaseURL = cclickApp.ApiURL;

function AjaxGenericMethod(method , controller, dataToPost) {
    
    //var UC_DBConnectionString = cclickApp.UC_DBConnectionString;

    //if (UC_DBConnectionString == null || UC_DBConnectionString == '')
    //{
    //    alert('!Error. Connection String Not Found! Login Again');
        
    //}

    if (dataToPost == null)
        dataToPost = {};
    
    url = BaseURL + controller + '/' + method;
    //dataToPost.UC_User = cclickApp.Token;
    //dataToPost.UC_DBConnectionString = UC_DBConnectionString;

    //if (cclickApp.AdminSchoolId != 0)
    //{
    //    dataToPost.UC_SchoolId = cclickApp.AdminSchoolId;
    //    cclickApp.AdminSchoolId = 0;
    //}
    //else
    //{
    //    dataToPost.UC_SchoolId = cclickApp.SchoolId;
    //}
    ShowProcessiongDiv();
    preshowloader(true, '50');
    try {
        $.support.cors = true;

    return    $.ajax({
            type: "POST",
            url: url,
            async: false,               
            data: dataToPost,
            cache: false,
            timeout: cclickApp.AjaxTimeOut,
            beforeSend: function ()
            {

                //preshowloader(true, '50');
                //enable loader
                //  $('.loader').fadeIn();
            },
           
            error: function (data, status)
            {
                // if (xhr.status == '401')
                //  window.location.href = '/Account/login';
                //console.log(errorThrown);
                // $('.loader').fadeOut();
                
              
            },
            complete: function ()
            {
                //disable loader
                //  $('.loader').fadeOut();
                HideProcessiongDiv();
                setTimeout(function () {
                    preshowloader(false);
                }, 500);
               
            }
           
        });
       
    }
    catch (e) {
        console.log(e);
    }
};


function UpdateSession(webUserCredential) {      
    jQuery.ajax({
        url: cclickApp.Webroot + 'Home/KeepSessionAlive',
        data: webUserCredential,
        type: 'GET',
        success: function (data)
        {
          if ($.isNumeric(data) != 1)
            {
              Logout();
            }


        },
        error: function (xhr, ajaxOptions, thrownError)
        {
           Logout();
        }
    });

}


function Logout()
{
   window.location.href = '@Url.Action("Login2", "Home")'
}


//$(function () 
//{
//   //setInterval(function () { UpdateSession(); }, 3000);
    
//});

function SetBredcrumb(text)
{
    $('.breadcrumbs').text(text);
}

function SetTheme(text) {    
    var webUserCredential = {};  
    webUserCredential.ThemeId = text;
    jQuery.ajax({
        url: cclickApp.Webroot + 'Home/UpdateTheme',
        data: webUserCredential,
        type: 'POST',
        success: function (data) {
            location.reload();

        }
    });
    
    
}

function ShowProcessiongDiv()
{
  
    $('.toastprocessingdiv').show();
 
}

function HideProcessiongDiv()
{
    $('.toastprocessingdiv').hide();
}
function ShowSuccessMessage(message)
{
    // SuccessToaster(message);
    $('.cssuccessmsgtoaster').html(message);
    $('.toast-trackSuccess').show();

    setTimeout(function () {
        $(".toast-trackSuccess").fadeOut('slow', function () {
           
        });
    }, 3000);
}
function ShowErrorMessage(message)
{
    $('.cserrorsmsgtoaster').html(message);
    $('.toast-trackError').show();
    setTimeout(function () {
        $(".toast-trackError").fadeOut('slow', function () {

        });
    }, 3000);
    // alert(message);
    //https://kamranahmed.info/toast
}

/***********************************Toaster**************************************************/
function SuccessToaster(message) {
    var priority = 'success';
    
    $.toaster
        ({
            priority: priority,
            title: "",
            message: message,
            closeButton: false,
            autoHide: false,
           
        });

    

}


/******************************Validations**********************************************/

function ValidateByJQ(className)
{
    var Response = "";
    cclickApp.isValidControl = 1;
    /************TextBox has text****************************/

    $('.' + className).find('.txtboxreqtext').each(function ()
    {
        var txtboxreqtext = $.trim( $(this).val());
        if ((txtboxreqtext != null && txtboxreqtext == '') || txtboxreqtext == null)
        {
            MarkControlValueInvalid($(this))
        }
        else
        {
            UnMarkControlValueInvalid($(this))
        }
    });

    /************TextBox has Numbers only****************************/

    $('.' + className).find('.txtboxreqnumbergreaterthenzero').each(function ()
    {

        var txtboxreqnumber = $(this).val().trim();
        var numbers = /^[0-9]+$/;
                 
        if ($.isNumeric(txtboxreqnumber) && parseInt(txtboxreqnumber) > 0 && txtboxreqnumber.match(numbers))
        {
          //  alert('ok numeric > 0');
            UnMarkControlValueInvalid($(this))
        }
        else
        {
            MarkControlValueInvalid($(this));
        }
    });

    /************************TextBox has Email *******************************/

    $('.' + className).find('.txtboxreqemail').each(function ()
    {

        var txtboxreqemail = $(this).val().trim();
      
        if (/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(txtboxreqemail))
        {
          
            UnMarkControlValueInvalid($(this))

        }
        else 
        {
            MarkControlValueInvalid($(this));
        }
    });


    /************TextArea has text****************************/

    $('.' + className).find('.textareareqtext').each(function ()
    {
       // alert('1');
        var textareareqtext = $.trim($(this).val());
        if ((textareareqtext != null && textareareqtext == '') || textareareqtext == null)
        {
           // alert('2');
            MarkControlValueInvalid($(this))
        }
        else
        {
            UnMarkControlValueInvalid($(this))
        }
    });

}






function MarkControlValueInvalid(control)
{
    cclickApp.isValidControl = 0;
    $(control).addClass('borderred');
}
function UnMarkControlValueInvalid(control)
{
    $(control).removeClass('borderred');
}




/*************************Delegates***********************************/

/*******************Red Border Removing************************/

$(document).delegate('.textareareqtext', 'click', function ()
{
    if ($(this).hasClass('borderred'))
    {
        $(this).removeClass('borderred');
    }
});

$(document).delegate('.txtboxreqtext', 'click', function ()
{
    if($(this).hasClass('borderred'))
    {
        $(this).removeClass('borderred');
    }
});

$(document).delegate('.txtboxreqnumbergreaterthenzero', 'click', function () 
{
    if ($(this).hasClass('borderred'))
    {
        $(this).removeClass('borderred');
    }
});

$(document).delegate('.txtboxreqemail', 'click', function ()
{
    if ($(this).hasClass('borderred'))
    {
        $(this).removeClass('borderred');
    }
});





$(".allownumericwithdecimal").on("keypress keyup blur", function (event)
{
   $(this).val($(this).val().replace(/[^0-9\.]/g, ''));
    if ((event.which != 46 || $(this).val().indexOf('.') != -1) && (event.which < 48 || event.which > 57)) {
        event.preventDefault();
    }
});


$(".allownumericwithoutdecimal").on("keypress keyup blur", function (event)
{
           $(this).val($(this).val().replace(/[^\d].+/, ""));
           if ((event.which < 48 || event.which > 57))
           {
                event.preventDefault();
            }
});


/************left Bar Movement*******************/

function ExpandLeftBar(liElementClass, InnerElementClass)
{
    //$('.commonli').find('a:first').removeClass('cam-minus');
    //$('.commonli').find('ul:first').removeClass('show');
    //$('.commoninnerlink').removeClass('activelink');
    //$('.' + liElementClass).find('a:first').addClass('cam-minus');
    //$('.' + liElementClass).find('ul:first').addClass('show');
    //$('.' + InnerElementClass).addClass('activelink');

    $('.commonli').find('a:first').removeClass('cam-minus');
    $('.commonli').find('ul:first').removeClass('show');
    $('.commoninnerlink').removeClass('active');
    $('.commonli').removeClass('active');
    $('.' + liElementClass).find('a:first').addClass('cam-minus');
    $('.' + liElementClass).find('ul:first').addClass('show');
    $('.' + InnerElementClass).css('background', 'rgb(19 174 210 / 25%)');
    $('.' + liElementClass).addClass('active');

}



/*****************Get Month Year ****************/

function GetMonthYear(Id) {
    var MonthYear = $('#' + Id).val();
    if (MonthYear == "")
    {
        $('#' + Id).addClass('borderred');
        return false;
    }
    else
    {
        $('#' + Id).removeClass('borderred');
        var MonthYear = MonthYear.split("-");
    }
    return MonthYear;
}




function preshowloader(option, cssTop) {
    if (option == true) {
        $('#loading-bar-spinner').show();
        $('#loading-bar-spinner').css({ "top": cssTop + "%" });
        $(".esm-bg").addClass("entitybgnew");


    }
    else {
        $('#loading-bar-spinner').hide();
        $("#oading-bar-spinner").removeAttr("top");
        $(".esm-bg").removeClass("entitybgnew");
    }

}