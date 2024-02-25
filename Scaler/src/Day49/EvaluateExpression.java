package Day49;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Stack;

public class EvaluateExpression {

	public static void main(String[] args) {
		ArrayList<String> A = new ArrayList<String>(Arrays.asList("2", "1", "+", "3", "*"));
		int ans = evalRPN(A);
		System.out.print(ans);
	}

	public static int evalRPN(ArrayList<String> A) {
		Stack<Integer> st = new Stack<>();
		for (int i = 0; i < A.size(); i++) {
			String str = A.get(i);

			if (str.equals("+") || str.equals("-") || str.equals("*") || str.equals("/")) {
				int num1 = st.pop();
				int num2 = st.pop();

				if (str.equals("+")) {
					st.push(num2 + num1);
				} else if (str.equals("-")) {
					st.push(num2 - num1);
				} else if (str.equals("*")) {
					st.push(num2 * num1);
				} else if (str.equals("/")) {
					st.push(num2 / num1);
				}
			} else {
				int val = Integer.parseInt(A.get(i));
				st.push(val);
			}
		}
		return st.peek();
	}
}
