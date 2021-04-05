function Site() {
    this.ajax = function (url, data, success) {
        $.ajax({
            type: "POST",
            url: url,
            data: JSON.stringify(data),
            success: success,
            contentType: 'application/json',
        });
    };    
}