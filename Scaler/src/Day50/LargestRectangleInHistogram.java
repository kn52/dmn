package Day50;

import java.util.Stack;

public class LargestRectangleInHistogram {

	public static void main(String[] args) {
		int[] A = new int[] { 2, 1, 5, 6, 2, 3 };
		int ans = largestRectangleArea(A);
		System.out.print(ans);
	}

	public static int largestRectangleArea(int[] A) {
		int[] nsl = nslFunc(A), nsr = nsrFunc(A);
		int ans = 0;
		for (int i = 0; i < A.length; i++) {
			int area = A[i] * (nsr[i] - nsl[i] - 1);
			ans = Math.max(ans, area);
		}
		return ans;
	}

	public static int[] nsrFunc(int[] A) {

		Stack<Integer> stack = new Stack<Integer>();
		int[] ans = new int[A.length];
		for (int i = A.length - 1; i >= 0; i--) {
			while (stack.size() != 0 && A[stack.peek()] >= A[i])
				stack.pop();
			if (stack.size() == 0)
				ans[i] = A.length;
			else
				ans[i] = stack.peek();
			stack.push(i);
		}
		return ans;
	}

	public static int[] nslFunc(int[] A) {

		Stack<Integer> stack = new Stack<Integer>();
		int[] ans = new int[A.length];
		for (int i = 0; i < A.length; i++) {
			while (stack.size() != 0 && A[stack.peek()] >= A[i])
				stack.pop();
			if (stack.size() == 0)
				ans[i] = -1;
			else
				ans[i] = stack.peek();
			stack.push(i);
		}
		return ans;
	}
}
