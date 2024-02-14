function userUpdate_Dialog() {
	var res = confirm("会員情報を更新してもよろしいですか?");
	if (res) {
		// OKボタンを押したときの処理
		return ture;
	} else {
		// キャンセルボタンを押したときの処理
		return false;
	}
}
