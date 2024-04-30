function Response (_isSuccess = false, _message = "", _data = null) {
    this.IsSuccess = _isSuccess;
    this.Message = _message;
    this.Data = _data;
}


module.exports = {
    "response":  Response
};