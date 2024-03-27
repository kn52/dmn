package Day68;

import java.util.*;

public class FractionalKnapsack {

	public static void main(String[] args) {
		// TODO Auto-generated method stub

	}

	public int solve(int[] A, int[] B, int C) {
		double[][] x = new double[A.length][3];
		int w = C;
		for (int i = 0; i < A.length; i++) {
			x[i][0] = A[i] * 1d / B[i];
			x[i][1] = A[i];
			x[i][2] = B[i];
		}

		double ans = 0;
		Arrays.sort(x, (a, b) -> Double.compare(b[0], a[0]));
		for (int i = 0; i < A.length; i++) {
			if (x[i][2] <= w) {
				ans += x[i][1];
				w -= x[i][2];
			} else {
				ans += x[i][1] * w / x[i][2];
				break;
			}
		}
		return (int) Math.floor(ans * 1000 / 10);
	}
}
