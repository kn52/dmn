package Day64;

import java.util.Arrays;
import java.util.*;

public class MinNumberOfSquares {

	static Scanner scanner = new Scanner(System.in);
	static int n = scanner.nextInt();
	static int[] dp = new int[n + 1];

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		Arrays.fill(dp, -1);
		int ans = calc(n);
		System.out.println(ans);

	}
	
	public static int calc(int n) {

		if (n == 0) {
			return 0;
		}
		if (dp[n] != -1) {
			return dp[n];
		}
		int ans = 1;
		for (int x = 1; x*x < n; x++) {
			int num = (int) (n - Math.pow(x, 2)); 
			ans = Math.min(n, calc(num));
		}
		dp[n] = 1 + ans;		
		return dp[n];
	}

	

}
