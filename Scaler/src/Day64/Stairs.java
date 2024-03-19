package Day64;

import java.util.*;

public class Stairs {
	static Scanner scanner = new Scanner(System.in);
	static int n, ans = 1;
	public static void main(String[] args) {
		// TODO Auto-generated method stub
		System.out.print("Enter number: ");
		n = scanner.nextInt();
		System.out.println(n);
		int[] dp = new int[n +1];
		Arrays.fill(dp, -1);
		ans = 1;
		int ans = fibonacci(n, dp);
		System.out.println(ans);
	}
	
	public static int fibonacci(int n, int[] dp) {
		
		if (n <= 2) {
			return 1;
		}
		if (dp[n] != -1) {
			return dp[n];
		}
		ans = fibonacci(n - 1, dp) + fibonacci(n - 2, dp);
		dp[n] = ans;
		
		return ans;
	}

}
