package Day49;

import java.util.Stack;

public class DoubleCharacterTrouble {

	public static void main(String[] args) {
		String A = "abccbc";
		String ans = solve(A);
		System.out.print(ans);
	}

	public static String solve(String A) {
		Stack<Character> stk = new Stack<Character>();
		for (int i = 0; i < A.length(); i++) {
			if (stk.isEmpty()) {
				stk.push(A.charAt(i));
			} else if (stk.peek().equals(A.charAt(i))) {
				stk.pop();
			} else {
				stk.push(A.charAt(i));
			}
		}

		StringBuilder sb = new StringBuilder();
		while (stk.isEmpty() == false) {
			sb.append(stk.pop());
		}
		return sb.reverse().toString();
	}
}
