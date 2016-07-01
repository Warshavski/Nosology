
//// selector function
function $selectElement(selector) {
    return document.querySelector(selector);
}

//var Login = (function () {

//    /**
//     * For ajax request uses with controller action that returns Json
     
//    var processLogOn = function () {
//        var userLogin = $selectElement('#loginInput').value;
//        var userPassword = $selectElement('#pwdInput').value;

//        var isValidInput = checkInput(userLogin, userPassword);
//        if (isValidInput) {

//            blockSubmit();

//            $.ajax({
//                type: 'POST',
//                url: '/Account/LogIn',
//                data:
//                    {
//                        UserName: userLogin,
//                        Password: userPassword,
//                        RememberMe: isPersist()
//                    },
//                dataType: 'json',

//                success: function (response) {
//                    window.location.href = response.Url;
//                },
//                error: function (xhr, ajaxOptions, thrownError) {
//                    errorLabel.innerText = thrownError;
//                    unBlockSubmit();
//                }
//            });
//        }
//    };
//    */

//    var logOnTrigger = $selectElement('.login-block__button');
//    var validationSummary = $selectElement('.validation-summary-errors');

//    var userLogin = $selectElement('#loginInput');
//    var userPassword = $selectElement('#pwdInput');

//    var processLogOn = function(event) {
//        blockSubmit();

//        if (!checkInputValues(userLogin.value, userPassword.value)) {
//            event.preventDefault();
//            validationSummary.innerText = 'Поля ввода не должны быть пустыми.'
//        }
//        else {
//            blockSubmit();
//        }
//    };

//    /**
//     * @param loginValue - user login
//     * @param passwordValue - user password
//     * @returns {bool} 
//     */
//    var checkInputValues = function (loginValue, passwordValue) {
//        var isValidValues = (loginValue.trim() != '' && passwordValue.trim() != '');

//        return isValidValues;
//    }

//    /**
//     * Block submit form.
//     */
//    var blockSubmit = function () {
//        $selectElement('.mdl-spinner').classList.add('is-active');
//        $selectElement('#logInButton').setAttribute('disabled', 'disabled');
//    };

//    /**
//     * Unblock submit form.
//     */
//    var unBlockSubmit = function () {
//        $selectElement('.mdl-spinner').classList.remove('is-active');
//        $selectElement('#logInButton').removeAttribute('disabled');
//    };

//    /**
//     * Clear error message label.
//     */
//    var clearValidationSummary = function () {
        
//        if (validationSummary.innerText != '') {
//            validationSummary.innerText = '';
//        } 
//    };

//    var bindActions = function () {
//        logOnTrigger.addEventListener('click', processLogOn);
//        userLogin.addEventListener('focus', clearValidationSummary);
//        userPassword.addEventListener('focus', clearValidationSummary);
//    };

//    var init = function () {
//        bindActions();
//    }

//    return {
//        init: init
//    };

//}());

//Login.init();


var blockSubmit = function () {
    $selectElement('.mdl-spinner').classList.add('is-active');
    $selectElement('#logInButton').setAttribute('disabled', 'disabled');
};