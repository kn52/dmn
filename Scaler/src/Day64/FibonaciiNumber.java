package Day64;

import java.util.Arrays;
import java.util.*;

public class FibonaciiNumber {

	static Scanner scanner = new Scanner(System.in);
	static int n = scanner.nextInt();
	static int[] dp = new int[n + 1];

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		Arrays.fill(dp, -1);
		int ans = fibonacci(n);
		System.out.println(ans);

	}

	public static int fibonacci(int n) {

		if (n <= 2) {
			return n;
		}
		if (dp[n] != -1) {
			return dp[n];
		}
		dp[n] = fibonacci(n - 1) + fibonacci(n - 2);
		
		return dp[n];
	}

}
