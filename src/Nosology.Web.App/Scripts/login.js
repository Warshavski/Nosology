var errorLabel = $selectElement('.login-block__label--error span');

function logIn() {
    var userLogin = $selectElement('#loginInput').value;
    var userPassword = $selectElement('#pwdInput').value;

    var isValidInput = checkInput(userLogin, userPassword);
    if (isValidInput) {

        blockSubmit();

        $.ajax({
            type: 'POST',
            url: '/Account/LogIn',
            data:
                {
                    UserName: userLogin,
                    Password: userPassword,
                    RememberMe: isPersist()
                },
            dataType: 'json',

            success: function (response) {
                window.location.href = response.Url;
            },
            error: function (xhr, ajaxOptions, thrownError) {
                errorLabel.innerText = thrownError;
                unBlockSubmit();
            }
        });
    }
}

// selector function
function $selectElement(selector) {
    return document.querySelector(selector);
}

// works fine
function checkInput(loginValue, passwordValue) {
    var isValid;
    if (loginValue.trim() != '' && passwordValue.trim() != '') {
        isValid = true;
    }
    else {
        isValid = false;
    }
    return isValid;
}

// works fine
function isPersist() {
    var checkBox = $selectElement('#persistCheckBox');

    var isPersist
    if (checkBox['checked']) {
        isPersist = true;
    }
    else {
        isPersist = false;
    }
    return isPersist;
}

function blockSubmit() {
    $selectElement('.mdl-spinner').classList.add('is-active');
    $selectElement('#logInButton').setAttribute('disabled', 'disabled');
}

function unBlockSubmit() {
    $selectElement('.mdl-spinner').classList.remove('is-active');
    $selectElement('#logInButton').removeAttribute('disabled');
}

// error label cleanup
function clearError() {
    if (errorLabel.innerText != '') {
        errorLabel.innerText = '';
    }
}
