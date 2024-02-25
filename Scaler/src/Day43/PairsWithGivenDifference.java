package Day43;

import java.util.Arrays;

public class PairsWithGivenDifference {

	public static void main(String[] args) {
		int ans = solve(new int[] { 1, 5, 3, 4, 2 }, 3);
		System.out.println(ans);
	}
	public static int solve(int[] A, int B) {
        int N = A.length;
        Arrays.sort(A);
        if (A == null || N < 2 || B < 0) {
        return 0;
        }
        int L = 0;
        int R = 1;

        int ans = 0;
        int[] _pair = {
        -1,
        -1
        };

        while (R < N) {
            if (A[R] - A[L] == B && L < R && (A[L] != _pair[0] || A[R] != _pair[1])) {
                ans++;
                _pair[0] = A[L];
                _pair[1] = A[R];
                L++;
                R++;
            } else if (A[R] - A[L] > B) {
                L++;
            } else {
                R++;
            }
        }
        return ans;
    }
}
