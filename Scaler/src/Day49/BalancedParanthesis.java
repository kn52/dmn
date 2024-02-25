package Day49;

import java.util.Stack;

public class BalancedParanthesis {

	public static void main(String[] args) {
		String A = "{([])}";
		int ans = solve(A);
		System.out.print(ans);
	}

	public static int solve(String A) {
		Stack<Character> stk = new Stack<>();
		for (int i = 0; i < A.length(); i++) {
			if (checkOpen(A.charAt(i))) {
				stk.push(A.charAt(i));
			} else {
				if (stk.empty()) {
					return 0;
				} else if (checkCloseWithOpen(stk.peek(), A.charAt(i))) {
					stk.pop();
				} else {
					return 0;
				}
			}
		}
		if (stk.empty()) {
			return 1;
		}

		return 0;
	}

	public static boolean checkCloseWithOpen(char x, char y) {
		if (x == '(' && y == ')') {
			return true;
		}
		if (x == '{' && y == '}') {
			return true;
		}
		if (x == '[' && y == ']') {
			return true;
		}
		return false;
	}

	public static boolean checkOpen(char x) {
		if (x == '(' || x == '{' || x == '[') {
			return true;
		}
		return false;
	}
}
