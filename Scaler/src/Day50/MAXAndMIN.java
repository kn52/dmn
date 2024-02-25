package Day50;

import java.util.Stack;

public class MAXAndMIN {

	public static void main(String[] args) {
		int[] A = new int[] { 4, 7, 3, 8 };
		int ans = solve(A);
		System.out.print(ans);
	}

	public static int solve(int[] A) {

		if (A.length == 1)
			return 0;
		long ans = 0;
		long mod = 1L * 1000000007;
		int[] ngl = new int[A.length];
		int[] ngr = new int[A.length];
		int[] nsl = new int[A.length];
		int[] nsr = new int[A.length];

		ngl = nglFunc(A);
		ngr = ngrFunc(A);
		nsl = nslFunc(A);
		nsr = nsrFunc(A);

		for (int i = 0; i < A.length; i++) {
			long max = 1L * (i - ngl[i]) * (ngr[i] - i);
			long min = 1L * (i - nsl[i]) * (nsr[i] - i);
			ans += (max - min) * A[i];
		}
		return (int) (ans % mod);
	}

	public static void printElement(int[] A) {
		for (int i = 0; i < A.length; i++) {
			System.out.print(A[i] + " ");
		}
	}

	public static int[] nslFunc(int[] A) {

		Stack<Integer> stack = new Stack<Integer>();
		int ans[] = new int[A.length];
		for (int i = 0; i < A.length; i++) {
			while (stack.size() != 0 && A[stack.peek()] >= A[i]) {
				stack.pop();
			}
			if (stack.size() == 0)
				ans[i] = -1;
			else
				ans[i] = stack.peek();
			stack.push(i);
		}
		return ans;
	}

	public static int[] nsrFunc(int[] A) {
		Stack<Integer> stack = new Stack<Integer>();
		int ans[] = new int[A.length];
		for (int i = A.length - 1; i >= 0; i--) {
			while (stack.size() != 0 && A[stack.peek()] >= A[i]) {
				stack.pop();
			}
			if (stack.size() == 0)
				ans[i] = A.length;
			else
				ans[i] = stack.peek();
			stack.push(i);
		}
		return ans;
	}

	public static int[] nglFunc(int[] A) {
		Stack<Integer> stack = new Stack<Integer>();
		int ans[] = new int[A.length];
		for (int i = 0; i < A.length; i++) {
			while (stack.size() != 0 && A[stack.peek()] <= A[i]) {
				stack.pop();
			}
			if (stack.size() == 0)
				ans[i] = -1;
			else
				ans[i] = stack.peek();
			stack.push(i);
		}
		return ans;
	}

	public static int[] ngrFunc(int[] A) {
		Stack<Integer> stack = new Stack<Integer>();
		int ans[] = new int[A.length];
		for (int i = A.length - 1; i >= 0; i--) {
			while (stack.size() != 0 && A[stack.peek()] <= A[i]) {
				stack.pop();
			}
			if (stack.size() == 0)
				ans[i] = A.length;
			else
				ans[i] = stack.peek();
			stack.push(i);
		}
		return ans;
	}
}
